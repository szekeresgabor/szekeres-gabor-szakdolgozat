import { Component } from '@angular/core';
import { MenuService } from './services/menu.service';
import { MenuItem } from 'ui-frontend-package';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'host';

  _menuItems: MenuItem[] = [];

  constructor(private menuService: MenuService) {
    this._menuItems = menuService.menuItems;
  }
}
