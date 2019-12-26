import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TaskListComponent } from '../modules/content/components/task-list-component/task-list.component';
import { SettingsComponent } from '../modules/content/components/settings-component/settings.component';


const routes: Routes = [
  { path: '', redirectTo: 'tasks', pathMatch: 'full'},
  { path: 'tasks',  component: TaskListComponent },
  { path: 'settings',  component: SettingsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
