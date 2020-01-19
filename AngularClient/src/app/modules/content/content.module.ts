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
import { CardPreviewComponent } from './components/card-preview-component/card-preview.component';
import { ExecutedTaskListComponent } from './components/executed-task-list-components/executed-task-list.component';
import { DeletedTaskListComponent } from './components/deleted-task-list-component/deleted-task-list.component';

@NgModule({
  declarations: [
    TaskListComponent, 
    SettingsComponent, 
    NewTaskComponent,
    CardPreviewComponent,
    ExecutedTaskListComponent,
    DeletedTaskListComponent
  ],
  exports: [
    TaskListComponent, 
    SettingsComponent,
    ExecutedTaskListComponent,
    DeletedTaskListComponent
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
