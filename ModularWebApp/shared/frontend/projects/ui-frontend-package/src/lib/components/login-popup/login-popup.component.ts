import { Component } from '@angular/core';
import { IdentityService, LoginRequest } from 'core-frontend-package';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'uip-login-popup',
  standalone: false,
  templateUrl: './login-popup.component.html',
  styleUrl: './login-popup.component.css'
})
export class LoginPopupComponent {
  visible = true;
  loginDTO: LoginRequest = new LoginRequest();

  destroy$: Subject<void> = new Subject<void>();

  constructor(private identityService: IdentityService) {
    this.identityService.username$
      .pipe(takeUntil(this.destroy$))
      .subscribe(name => {
        this.visible = !name;
      });

  }

  login(): void {
    this.identityService.login(this.loginDTO).subscribe((token: string) => {
      if (token) {
        this.visible = false;
      }
    });
  }
}
