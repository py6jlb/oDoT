import { Component, OnInit } from '@angular/core';
import { ContentDataService } from '../../services/content-data.service';
import { SettingsModel } from '../../models/settings-model';
import { Validators, FormGroup, FormControl, FormGroupDirective } from '@angular/forms';

@Component({
    selector: 'app-settings',
    templateUrl: './settings.component.html',
    styleUrls: ['./settings.component.scss']
})

export class SettingsComponent implements OnInit {
    milisecInDay = 86400000;
    milisecInHour = 3600000
    milisecInMin = 60000;

    settings: SettingsModel;
    settingsForm = new FormGroup({
        "deadlineDays": new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern(/^(?:[1-9][0-9]*|0)$/)]),
        "deadlineHours": new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern(/^(?:[1-9][0-9]*|0)$/)]),
        "deadlineMinuts": new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern(/^(?:[1-9][0-9]*|0)$/)]),

        "panicDays": new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern(/^(?:[1-9][0-9]*|0)$/)]),
        "panicHours": new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern(/^(?:[1-9][0-9]*|0)$/)]),
        "panicMinuts": new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern(/^(?:[1-9][0-9]*|0)$/)]),

        "startPanicDays": new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern(/^(?:[1-9][0-9]*|0)$/)]),
        "startPanicHours": new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern(/^(?:[1-9][0-9]*|0)$/)]),
        "startPanicMinuts": new FormControl(0, [Validators.required, Validators.min(0), Validators.pattern(/^(?:[1-9][0-9]*|0)$/)]),
    })
    constructor(private dataService: ContentDataService) { }

    ngOnInit() {
        this.dataService.getSettings().subscribe(x=>{
            this.settings = new SettingsModel(x);
            this.setFormData();
        })
    }

    private setFormData(){
        let deadlineremainder = this.settings.deadlineTimeSpanInMiliseconds;

        let deadlineDays = Math.floor(deadlineremainder/this.milisecInDay)
        this.settingsForm.controls['deadlineDays'].setValue(deadlineDays)
        deadlineremainder = deadlineremainder - deadlineDays*this.milisecInDay;
        
        let deadlineHours = Math.floor(deadlineremainder/this.milisecInHour)
        this.settingsForm.controls['deadlineHours'].setValue(deadlineHours)
        deadlineremainder = deadlineremainder - deadlineHours*this.milisecInHour;
        
        let deadlineMinuts = Math.floor(deadlineremainder/this.milisecInMin)
        this.settingsForm.controls['deadlineMinuts'].setValue(deadlineMinuts)
        deadlineremainder = deadlineremainder - deadlineMinuts*this.milisecInMin;

        let panicremainder = this.settings.panicTimeSpanInMiliseconds;
                
        let panicDays = Math.floor(panicremainder/this.milisecInDay)
        this.settingsForm.controls['panicDays'].setValue(panicDays)
        panicremainder = panicremainder - panicDays*this.milisecInDay;
        
        let panicHours = Math.floor(panicremainder/this.milisecInHour)
        this.settingsForm.controls['panicHours'].setValue(panicHours)
        panicremainder = panicremainder - panicHours*this.milisecInHour;
        
        let panicMinuts = Math.floor(panicremainder/this.milisecInMin)
        this.settingsForm.controls['panicMinuts'].setValue(panicMinuts)
        panicremainder = panicremainder - panicMinuts*this.milisecInMin;

        let startPanicremainder = this.settings.startPanicForTimeSpanInMiliseconds;
                
        let startPanicDays = Math.floor(startPanicremainder/this.milisecInDay)
        this.settingsForm.controls['startPanicDays'].setValue(startPanicDays)
        startPanicremainder = startPanicremainder - startPanicDays*this.milisecInDay;
        
        let startPanicHours = Math.floor(startPanicremainder/this.milisecInHour)
        this.settingsForm.controls['startPanicHours'].setValue(startPanicHours)
        startPanicremainder = startPanicremainder - startPanicHours*this.milisecInHour;
        
        let startPanicMinuts = Math.floor(startPanicremainder/this.milisecInMin)
        this.settingsForm.controls['startPanicMinuts'].setValue(startPanicMinuts)
        startPanicremainder = startPanicremainder - startPanicMinuts*this.milisecInMin;

    }

    private updateSettings(){
        this.settings.deadlineTimeSpanInMiliseconds = this.settingsForm.controls['deadlineDays'].value * this.milisecInDay +
                                                    this.settingsForm.controls['deadlineHours'].value * this.milisecInHour +
                                                    this.settingsForm.controls['deadlineMinuts'].value * this.milisecInMin
        this.settings.panicTimeSpanInMiliseconds = this.settingsForm.controls['panicDays'].value * this.milisecInDay +
                                                    this.settingsForm.controls['panicHours'].value * this.milisecInHour +
                                                    this.settingsForm.controls['panicMinuts'].value * this.milisecInMin
        this.settings.startPanicForTimeSpanInMiliseconds = this.settingsForm.controls['startPanicDays'].value * this.milisecInDay +
                                                    this.settingsForm.controls['startPanicHours'].value * this.milisecInHour +
                                                    this.settingsForm.controls['startPanicMinuts'].value * this.milisecInMin
                                                     
    }       

    submitForm(formDirective: FormGroupDirective): void {
        this.updateSettings();
        this.dataService.saveSettings(this.settings).subscribe(x=>{
            console.log(x);
        })
    }


}