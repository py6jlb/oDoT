import { Component, OnInit } from '@angular/core';
import { ContentDataService } from '../../services/content-data.service';
import { SettingsModel } from '../../models/settings-model';
import { Validators, FormGroup, FormControl, FormGroupDirective } from '@angular/forms';
import {MomentDateAdapter, MAT_MOMENT_DATE_ADAPTER_OPTIONS} from '@angular/material-moment-adapter';
import { MatDialogRef } from '@angular/material/dialog';
import { DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material/core';
import { POINTED_DATE_FORMATS } from 'src/app/shared/PointedDateFormats';
import { ICardModel, ICardContentModel } from '../../@types/tasks';

@Component({
    selector: 'app-new-task',
    templateUrl: './new-task.component.html',
    styleUrls: ['./new-task.component.scss'],
    providers: [
        {
          provide: DateAdapter,
          useClass: MomentDateAdapter,
          deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS]
        },
        {
          provide: MAT_DATE_FORMATS, 
          useValue: POINTED_DATE_FORMATS
        },
        {
          provide: MAT_DATE_LOCALE, 
          useValue: 'ru'
        },
      ]
})

export class NewTaskComponent implements OnInit {
    milisecInDay = 86400000;
    milisecInHour = 3600000
    milisecInMin = 60000;
    milisecInSec = 1000;

    settings: SettingsModel;

    newTaskForm = new FormGroup({
        "taskName": new FormControl("", [Validators.required]),
        "taskText": new FormControl("", []),
        "taskPriority": new FormControl(null, [Validators.required]),

        "startPanicDate": new FormControl(null, [Validators.required]),
        "deadlineDate": new FormControl(null, [Validators.required]),

        "panicDays": new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern(/^(?:[1-9][0-9]*|0)$/)]),
        "panicHours": new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern(/^(?:[1-9][0-9]*|0)$/)]),
        "panicMinuts": new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern(/^(?:[1-9][0-9]*|0)$/)]),

        "doNotDisturbDays": new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern(/^(?:[1-9][0-9]*|0)$/)]),
        "doNotDisturbHours": new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern(/^(?:[1-9][0-9]*|0)$/)]),
        "doNotDisturbMinuts": new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern(/^(?:[1-9][0-9]*|0)$/)])
        
    })
    constructor(public dataService: ContentDataService, private dialogRef: MatDialogRef<NewTaskComponent>) { }

    ngOnInit() {
        this.dataService.getSettings().subscribe(x=>{
            this.settings = new SettingsModel(x);
            this.setFormData();
        })
    }

    private setFormData(){

        let deadLineDate = new Date(Date.now() + this.settings.deadlineTimeSpanInMiliseconds);
        this.newTaskForm.controls['deadlineDate'].setValue(deadLineDate)

        let startPanicDate = new Date(Date.now() + this.settings.startPanicForTimeSpanInMiliseconds);
        this.newTaskForm.controls['startPanicDate'].setValue(startPanicDate)

        let panicremainder = this.settings.panicTimeSpanInMiliseconds;
                
        let panicDays = Math.floor(panicremainder/this.milisecInDay)
        this.newTaskForm.controls['panicDays'].setValue(panicDays)
        panicremainder = panicremainder - panicDays*this.milisecInDay;
        
        let panicHours = Math.floor(panicremainder/this.milisecInHour)
        this.newTaskForm.controls['panicHours'].setValue(panicHours)
        panicremainder = panicremainder - panicHours*this.milisecInHour;
        
        let panicMinuts = Math.floor(panicremainder/this.milisecInMin)
        this.newTaskForm.controls['panicMinuts'].setValue(panicMinuts)
        panicremainder = panicremainder - panicMinuts*this.milisecInMin;

    }

    private updateSettings(){
                                                     
    }       

    addTask(){
      var data = {
        id: null,
        name: this.newTaskForm.controls['taskName'].value,
        createDateTime: Date.now(),
        deadLineDateTime: this.newTaskForm.controls['deadlineDate'].value._d != null ?
                        this.newTaskForm.controls['deadlineDate'].value._d.getTime() 
                        : this.newTaskForm.controls['deadlineDate'].value.getTime(),
        startPanicDateTime: this.newTaskForm.controls['startPanicDate'].value._d != null ?
                        this.newTaskForm.controls['startPanicDate'].value._d.getTime() 
                        : this.newTaskForm.controls['startPanicDate'].value.getTime(),
        panicIntervalInMiliseconds: this.newTaskForm.controls['panicDays'].value * this.milisecInDay +
                          this.newTaskForm.controls['panicHours'].value * this.milisecInHour +
                          this.newTaskForm.controls['panicMinuts'].value * this.milisecInMin,
        defferalCount: 0,
        status: 1,
        priority: this.newTaskForm.controls['taskPriority'].value,
        content: {id: null, text: this.newTaskForm.controls['taskText'].value} as ICardContentModel,
        cardComments:[]
      } as ICardModel

      this.dataService.addNewTask(data).subscribe(x=>{
        this.dialogRef.close(x);
      })
    }


}