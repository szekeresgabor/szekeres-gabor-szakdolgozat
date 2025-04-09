import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'uip-layout',
  standalone: false,
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {
  menuItems = [
    { text: 'Főoldal', path: '/home' },
    { text: 'Szolgáltatások', path: '/services' },
    { text: 'Kapcsolat', path: '/contact' },
  ];

  constructor(private router: Router) { }

  navigate(e: any) {
    if (e.itemData?.path) {
      this.router.navigate([e.itemData.path]);
    }
  }
}
