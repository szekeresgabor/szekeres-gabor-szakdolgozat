import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ErrorPopupService {
  private errorSubject = new Subject<{ message: string; correlationId: string }>();

  error$ = this.errorSubject.asObservable();

  showError(message: string, correlationId: string) {
    this.errorSubject.next({ message, correlationId });
  }
}