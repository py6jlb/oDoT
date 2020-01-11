import { NgModule } from "@angular/core";
import { TaskListComponent } from "./components/task-list-component/task-list.component";
import { ContentDataService } from "./services/content-data.service";
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { MaterialModule } from "../material/material.module";
import { SettingsComponent } from './components/settings-component/settings.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NewTaskComponent } from './components/new-task-component/new-task.component';
import { CommonModule } from '@angular/common';
import { NgxMatDatetimePickerModule, NgxMatTimepickerModule } from 'ngx-mat-datetime-picker';

@NgModule({
  declarations: [
    TaskListComponent, 
    SettingsComponent, 
    NewTaskComponent
  ],
  exports: [
    TaskListComponent, 
    SettingsComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    HttpClientModule,
    FontAwesomeModule,
    FormsModule,
    ReactiveFormsModule,
    NgxMatDatetimePickerModule,
    NgxMatTimepickerModule
  ],
  entryComponents: [
    NewTaskComponent
  ],
  providers: [
    ContentDataService
  ]
})
export class ContentModule { }
