import { Component, OnInit } from '@angular/core';
import { ContentDataService } from '../../services/content-data.service';
import { CardModel } from '../../models/card.model';
import { ConfigService } from 'src/app/shared/services/config.service';

@Component({
    selector: 'app-task-list',
    templateUrl: './task-list.component.html',
    styleUrls: ['./task-list.component.scss']
})

export class TaskListComponent implements OnInit {    
    taskWithHigthPriority:CardModel[] = [];
    taskWithnormalPriority:CardModel[] = [];
    taskWithPanic:CardModel[] = [];
    
    constructor(private dataService: ContentDataService, private config: ConfigService) { }

    ngOnInit() { }
}