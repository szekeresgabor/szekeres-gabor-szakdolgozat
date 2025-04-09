import { ErrorHandler, Injectable } from '@angular/core';
import { ErrorPopupService } from './error-popup.service';

@Injectable({ providedIn: 'root' })
export class ErrorService implements ErrorHandler {
  constructor(private errorPopup: ErrorPopupService) { }

  handleError(error: any): void {
    const correlationId = error?.correlationId || error?.error?.correlationId || 'ismeretlen';
    const message = error?.message || error?.error?.message || 'Ismeretlen hiba történt.';

    this.errorPopup.showError(message, correlationId);
  }
}
