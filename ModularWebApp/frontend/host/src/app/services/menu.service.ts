import { Injectable } from '@angular/core';
import { MenuItem } from 'ui-frontend-package';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  menuItems: MenuItem[] = [
    { text: 'Ügyfélkezelő', path: '/ugyfelkezelo', roles: ['ugyfelkezelo'] },
    { text: 'Panaszkezelő', path: '/panaszkezelo', roles: ['panaszkezelo'] },
    { text: 'Szerződéskezelő', path: '/szerzodeskezelo', roles: ['szerzodeskezelo'] }
  ];

  constructor() { }
}
