import { NgModule } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MainToolbarComponent } from './components/main-toolbar-component/main-toolbar.comonent';
import { MaterialModule } from '../material/material.module';

@NgModule({
  imports: [
    MaterialModule,
    FontAwesomeModule    
  ],
  declarations:[
    MainToolbarComponent
  ],
  exports:[
    MainToolbarComponent
  ],
  providers: []
})
export class MainToolbarModule { }
