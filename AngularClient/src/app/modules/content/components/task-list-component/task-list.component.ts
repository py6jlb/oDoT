import { Component, OnInit } from '@angular/core';
import { ContentDataService } from '../../services/content-data.service';
import { CardModel } from '../../models/card.model';
import { ConfigService } from 'src/app/shared/services/config.service';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { MatDialogConfig, MatDialog } from '@angular/material/dialog';
import { NewTaskComponent } from '../new-task-component/new-task.component';

@Component({
    selector: 'app-task-list',
    templateUrl: './task-list.component.html',
    styleUrls: ['./task-list.component.scss']
})

export class TaskListComponent implements OnInit {    
    taskWithHigthPriority:CardModel[] = [];
    taskWithnormalPriority:CardModel[] = [];
    taskWithPanic:CardModel[] = [];
    faPlus = faPlus;
    
    constructor(
        private dataService: ContentDataService, 
        private config: ConfigService,
        private dialog: MatDialog
        ) { }

    ngOnInit() { }

    openNewTaskDialog(){
        const dialogConfig = new MatDialogConfig();
        dialogConfig.data = {data: 1};
        dialogConfig.width = '1000px';
        dialogConfig.disableClose = true;
        const dialogRef = this.dialog.open(NewTaskComponent, dialogConfig);
        dialogRef.afterClosed().subscribe(x=>{
            console.log(x)
        })
    }
}