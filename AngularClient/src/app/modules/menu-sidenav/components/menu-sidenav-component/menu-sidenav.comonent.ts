import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-menu-sidenav',
  templateUrl: './menu-sidenav.component.html',
  styleUrls: ['./menu-sidenav.component.scss']
})
export class MenuSidenavComponent {
  @Input() menuIsopened: boolean;
}
