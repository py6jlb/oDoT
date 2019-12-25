import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { faBars } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-main-toolbar',
  templateUrl: './main-toolbar.component.html',
  styleUrls: ['./main-toolbar.component.scss']
})
export class MainToolbarComponent {
    faBars = faBars;

    @Output() menuToggled = new EventEmitter<void>();

    toggleMenuClickhandler(){
      this.menuToggled.emit();
    }
}
