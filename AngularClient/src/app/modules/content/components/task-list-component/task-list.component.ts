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
  taskWithHigthPriority: CardModel[] = [];
  taskWithNormalPriority: CardModel[] = [];
  taskWithPanic: CardModel[] = [];
  faPlus = faPlus;

  constructor(
    private dataService: ContentDataService,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.loadData();
  }

  openNewTaskDialog() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = { data: 1 };
    dialogConfig.width = "1000px";
    dialogConfig.disableClose = true;
    const dialogRef = this.dialog.open(NewTaskComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(x => {
      if (x.priority === TaskPriorityEnum.Normal)
        this.taskWithNormalPriority.push(new CardModel(x));

      if (x.priority === TaskPriorityEnum.Higth)
        this.taskWithHigthPriority.push(new CardModel(x));
    })
  }

  private loadData() {
    this.dataService.getTasksByStatus(TaskStatusEnum.Open).subscribe(x => {
      if (x != null && x.length > 0) {
        let normal = x.filter(x => x.priority === TaskPriorityEnum.Normal);
        let higth = x.filter(x => x.priority === TaskPriorityEnum.Higth);

        if (normal != null && normal.length > 0)
          this.taskWithNormalPriority = normal.map(x => {
            return new CardModel(x);
          });

        if (higth != null && higth.length > 0)
          this.taskWithHigthPriority = higth.map(x => {
            return new CardModel(x);
          });
      }
    });
  }

  public taskDeleted(data: CardModel) {
    this.dataService.deleteTask(data.id).subscribe(x => {
      this.taskWithHigthPriority = this.taskWithHigthPriority.filter(x => x.id !== data.id);
      this.taskWithNormalPriority = this.taskWithNormalPriority.filter(x => x.id !== data.id);
    })
  }

  public taskClosed(data: CardModel) {
    this.dataService.closeTask(data).subscribe(x => {
      this.taskWithHigthPriority = this.taskWithHigthPriority.filter(x => x.id !== data.id);
      this.taskWithNormalPriority = this.taskWithNormalPriority.filter(x => x.id !== data.id);
    })
  }
}
