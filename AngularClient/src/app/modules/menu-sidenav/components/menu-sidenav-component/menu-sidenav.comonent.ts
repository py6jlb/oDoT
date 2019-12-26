import { Component } from '@angular/core';
import { faCheck, faTrash, faTasks, faCog, faChartLine } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-menu-sidenav',
  templateUrl: './menu-sidenav.component.html',
  styleUrls: ['./menu-sidenav.component.scss']
})
export class MenuSidenavComponent {
  faCheck=faCheck;
  faTrash=faTrash;
  faTasks=faTasks;
  faCog=faCog;
  faChartLine = faChartLine;
}
