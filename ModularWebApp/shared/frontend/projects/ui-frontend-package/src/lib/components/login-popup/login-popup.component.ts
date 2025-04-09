import { Component } from '@angular/core';
import { IdentityService, LoginRequest } from 'core-frontend-package';

@Component({
  selector: 'uip-login-popup',
  standalone: false,
  templateUrl: './login-popup.component.html',
  styleUrl: './login-popup.component.css'
})
export class LoginPopupComponent {
  visible = true;
  username = '';
  password = '';

  loginDTO: LoginRequest = new LoginRequest();

  constructor(private identity: IdentityService) {
    this.visible = identity.getToken() ? false : true;

  }

  login(): void {
    this.identity.login(this.loginDTO).subscribe();
  }
}
