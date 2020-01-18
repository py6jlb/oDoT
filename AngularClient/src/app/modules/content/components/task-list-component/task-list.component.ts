import { Component, OnInit } from "@angular/core";
import { ContentDataService } from "../../services/content-data.service";
import { CardModel } from "../../models/card.model";
import { ConfigService } from "src/app/shared/services/config.service";
import { faPlus } from "@fortawesome/free-solid-svg-icons";
import { MatDialogConfig, MatDialog } from "@angular/material/dialog";
import { NewTaskComponent } from "../new-task-component/new-task.component";
import { TaskStatusEnum } from "src/app/shared/enums/taskStatusEnum";
import { TaskPriorityEnum } from "src/app/shared/enums/taskPriorityEnum";

@Component({
  selector: "app-task-list",
  templateUrl: "./task-list.component.html",
  styleUrls: ["./task-list.component.scss"]
})
export class TaskListComponent implements OnInit {
  tasks: CardModel[] = [];
  faPlus = faPlus;
  dateNow = Date.now();

  constructor(
    private dataService: ContentDataService,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.loadData();

    setInterval(() => {
      this.dateNow = Date.now();
    }, 1000);
  }

  openNewTaskDialog() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = { data: 1 };
    dialogConfig.width = "1000px";
    dialogConfig.disableClose = true;
    const dialogRef = this.dialog.open(NewTaskComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(x => {
      if (x != null)
        this.tasks.push(new CardModel(x));

    })
  }

  private loadData() {
    this.dataService.getTasksByStatus(TaskStatusEnum.Open).subscribe(x => {
      if (x != null && x.length > 0) {
        this.tasks = x.map(x => { return new CardModel(x) });
        this.orderTasks();
      } else {
        this.tasks = [];
      }
    });
  }

  private orderTasks() {
    //   let normal = this.tasks.filter(x => x.priority === TaskPriorityEnum.Normal).sort((a,b)=>{
    //       return a.deadLineDateTime.getTime() < b.deadLineDateTime.getTime() ? 1 : -1
    //   });
    //   let higth = this.tasks.filter(x => x.priority === TaskPriorityEnum.Higth).sort((a,b)=>{
    //     return a.deadLineDateTime.getTime() < b.deadLineDateTime.getTime() ? 1 : -1
    // });
    this.tasks.sort((a, b) => {
      return a.deadLineDateTime.getTime() - b.deadLineDateTime.getTime();
    })

  }

  public taskDeleteHandler(data: CardModel) {
    this.dataService.deleteTask(data.id).subscribe(x => {
      this.tasks = this.tasks.filter(x => x.id !== data.id);
    })
  }

  public taskCloseHandler(data: CardModel) {
    data.status = TaskStatusEnum.Close;
    this.dataService.updateTask(data).subscribe(x => {
      this.tasks = this.tasks.filter(x => x.id !== data.id);
    })
  }

  public deadLineCahngeHandler(period: number, data: CardModel) {
    var updatetdDate = new Date(data.deadLineDateTime.getTime() + period);
    data.deadLineDateTime = updatetdDate;
    this.dataService.updateTask(data).subscribe(x => {
      const task = this.tasks.filter(x => x.id === data.id)[0];
      if (task != null)
        this.tasks.filter(x=>x.id === data.id)[0].deadLineDateTime = updatetdDate;
        this.orderTasks();
    })
  }
}
