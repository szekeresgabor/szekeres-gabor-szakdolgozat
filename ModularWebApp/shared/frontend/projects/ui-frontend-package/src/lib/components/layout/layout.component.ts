import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IdentityService } from 'core-frontend-package';
import { Subject, takeUntil } from 'rxjs';
import { MenuItem } from '../../models/menu-item.model';

@Component({
  selector: 'uip-layout',
  standalone: false,
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent implements OnInit, OnDestroy {
  @Input() menuItems: MenuItem[] = [];
  filteredMenuItems: MenuItem[] = [];

  username: string | null = null;
  isAuthenticated: boolean = false;

  destroy$: Subject<void> = new Subject<void>();

  constructor(
    private router: Router,
    private identityService: IdentityService
  ) { }

  ngOnInit(): void {
    this.identityService.roles$
      .pipe(takeUntil(this.destroy$))
      .subscribe(roles => {
        this.filteredMenuItems = this.menuItems.filter(item => {
          return !item.roles || item.roles.some(r => roles.includes(r));
        });
      });


    this.identityService.username$
      .pipe(takeUntil(this.destroy$))
      .subscribe(name => {
        this.username = name;
        this.isAuthenticated = !!name;
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.unsubscribe();
  }

  logout(): void {
    this.identityService.logout();
    this.router.navigate(['/']);
    this.isAuthenticated = false;
    this.username = null;
  }

  navigate(e: any) {
    if (e.itemData?.path) {
      this.router.navigate([e.itemData.path]);
    }
  }
}