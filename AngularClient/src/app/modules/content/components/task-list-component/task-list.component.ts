import { Component, OnInit } from '@angular/core';
import { ContentDataService } from '../../services/content-data.service';
import { CardModel } from '../../models/card.model';

@Component({
    selector: 'app-task-list',
    templateUrl: './task-list.component.html',
    styleUrls: ['./task-list.component.scss']
})

export class TaskListComponent implements OnInit {    
    taskWithHigthPriority:CardModel[] = [];
    taskWithnormalPriority:CardModel[] = [];
    taskWithPanic:CardModel[] = [];
    
    constructor(private dataService: ContentDataService) { }

    ngOnInit() { }
}