import { Component, OnInit } from "@angular/core";
import { ContentDataService } from "../../services/content-data.service";
import { CardModel } from "../../models/card.model";
import { TaskStatusEnum } from "src/app/shared/enums/taskStatusEnum";

@Component({
  selector: "app-executed-task-list",
  templateUrl: "./executed-task-list.component.html",
  styleUrls: ["./executed-task-list.component.scss"]
})
export class ExecutedTaskListComponent implements OnInit {
  tasks: CardModel[] = [];

  constructor(private dataService: ContentDataService) { }

  ngOnInit() {
    this.loadData();
  }

  private loadData() {
    this.dataService.getTasksByStatus(TaskStatusEnum.Close).subscribe(x => {
      if (x != null && x.length > 0) {
        this.tasks = x.map(x => { return new CardModel(x) }).filter(x=> x.deadLineDateTime!= null);
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
}
