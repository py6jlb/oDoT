import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TaskListComponent } from '../modules/content/components/task-list-component/task-list.component';
import { SettingsComponent } from '../modules/content/components/settings-component/settings.component';
import { ExecutedTaskListComponent } from '../modules/content/components/executed-task-list-components/executed-task-list.component';
import { DeletedTaskListComponent } from '../modules/content/components/deleted-task-list-component/deleted-task-list.component';


const routes: Routes = [
  { path: '', redirectTo: 'tasks', pathMatch: 'full'},
  { path: 'tasks',  component: TaskListComponent },
  { path: 'executed',  component: ExecutedTaskListComponent },
  { path: 'deleted',  component: DeletedTaskListComponent },
  { path: 'settings',  component: SettingsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
