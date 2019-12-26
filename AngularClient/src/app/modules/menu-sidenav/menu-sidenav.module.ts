import { NgModule } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaterialModule } from '../material/material.module';
import { MenuSidenavComponent } from './components/menu-sidenav-component/menu-sidenav.comonent';
import { AppRoutingModule } from 'src/app/routing/app-routing.module';

@NgModule({
  imports: [
    MaterialModule,
    AppRoutingModule,
    FontAwesomeModule,
    FontAwesomeModule
  ],
  declarations:[
    MenuSidenavComponent
  ],
  exports:[
    MenuSidenavComponent
  ],
  providers: []
})
export class MenuSidenavModule { }
