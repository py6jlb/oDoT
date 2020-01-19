import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { AppRoutingModule } from './routing/app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './modules/material/material.module';
import { MainToolbarModule } from './modules/main-toolbar/main-toolbar.module';
import { MenuSidenavModule } from './modules/menu-sidenav/menu-sidenav.module';
import { ContentModule } from './modules/content/content.module';
import { ConfigService } from './shared/services/config.service';


export function loadConfig(configService: ConfigService) {
  return () => configService.loadConfig();
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    MaterialModule,
    BrowserAnimationsModule,
    MainToolbarModule,
    MenuSidenavModule,
    ContentModule
  ],
  providers: [
    ConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: loadConfig,
      deps: [ConfigService],
      multi: true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  
 }
