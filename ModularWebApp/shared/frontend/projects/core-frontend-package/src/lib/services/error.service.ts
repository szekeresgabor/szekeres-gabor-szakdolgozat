import { ErrorHandler, Injectable } from '@angular/core';
import { ErrorPopupService } from './error-popup.service';

@Injectable({ providedIn: 'root' })
export class ErrorService implements ErrorHandler {
  constructor(private errorPopup: ErrorPopupService) { }

  handleError(error: any): void {
    // Próbáljuk meg kibontani a választ
    const response = error?.error ?? error;
    const correlationId = response?.correlationId || response?.traceId || 'ismeretlen';

    let message = 'Ismeretlen hiba történt.';

    // Ha van "errors" mező (model validation hiba)
    if (response?.errors && typeof response.errors === 'object') {
      const validationMessages = Object.entries(response.errors)
        .flatMap(([_, msgs]) => msgs as string[])
        .join('\n');
      message = `Hibás adatok:\n${validationMessages}`;
    }
    // Ha van "message" vagy "detail" mező
    else if (response?.message) {
      message = response.message;
      if (response?.detail) {
        message += `\nRészletek: ${response.detail}`;
      }
    }
    // Ha csak egy string hibaüzenet van
    else if (typeof response === 'string') {
      message = response;
    }

    // Hibát megjelenítjük a felugróban
    this.errorPopup.showError(message, correlationId);
  }
}