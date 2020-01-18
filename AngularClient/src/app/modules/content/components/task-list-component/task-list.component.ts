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
    var model = this.dataService.getICardModel(data);
    model.status = TaskStatusEnum.Close
    this.dataService.updateTask(model).subscribe(x => {
      data.status = TaskStatusEnum.Close;
      this.tasks = this.tasks.filter(x => x.id !== data.id);
    })
  }

  public deadLineCahngeHandler(period: number, data: CardModel) {
    var updatetdDate =data.deadLineDateTime.getTime() + period;
    var model = this.dataService.getICardModel(data);
    model.deadLineDateTime = updatetdDate
    this.dataService.updateTask(model).subscribe(x => {
        data.deadLineDateTime = new Date(updatetdDate);
    })
  }
}
