import { NgModule } from "@angular/core";
import { TaskListComponent } from "./components/task-list-component/task-list.component";
import { ContentDataService } from "./services/content-data.service";
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { MaterialModule } from "../material/material.module";
import { SettingsComponent } from './components/settings-component/settings.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [TaskListComponent, SettingsComponent],
  exports: [TaskListComponent, SettingsComponent],
  imports: [MaterialModule, HttpClientModule, FontAwesomeModule],
  providers: [ContentDataService]
})
export class ContentModule {}
