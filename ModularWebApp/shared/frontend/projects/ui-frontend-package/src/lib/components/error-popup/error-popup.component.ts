import { Component, OnInit } from '@angular/core';
import { ErrorPopupService } from 'core-frontend-package';

@Component({
  selector: 'uip-error-popup',
  standalone: false,
  templateUrl: './error-popup.component.html',
  styleUrl: './error-popup.component.css'
})
export class ErrorPopupComponent implements OnInit {
  visible = false;
  message = '';
  correlationId = '';

  constructor(private errorPopupService: ErrorPopupService) { }

  ngOnInit(): void {
    this.errorPopupService.error$.subscribe(({ message, correlationId }) => {
      this.message = message;
      this.correlationId = correlationId;
      this.visible = true;
    });
  }
}
