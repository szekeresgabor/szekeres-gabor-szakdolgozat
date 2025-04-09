import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { interval, Observable, Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { LoginRequest } from '../generated/identity-api';


@Injectable({ providedIn: 'root' })
export class IdentityService {
  private readonly baseUrl = 'http://localhost:5096/api/Auth';
  private tokenKey = 'jwt-token';
  private renewTimer?: Subscription;

  constructor(private http: HttpClient) {
    const existingToken = this.getToken();
    if (existingToken) {
      this.startRenewTimer();
    }
  }

  login(data: LoginRequest): Observable<string> {
    return this.http.post(this.baseUrl + '/login', data, { responseType: 'text' }).pipe(
      tap(token => {
        this.setToken(token);
        this.startRenewTimer();
      })
    );
  }

  renew(): Observable<string> {
    return this.http.post(this.baseUrl + '/renew', {}, { responseType: 'text' }).pipe(
      tap(token => this.setToken(token))
    );
  }

  private setToken(token: string): void {
    localStorage.setItem(this.tokenKey, token);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey);
    this.stopRenewTimer();
  }

  private startRenewTimer(): void {
    this.stopRenewTimer();
    this.renewTimer = interval(5 * 60 * 1000).subscribe(() => {
      this.renew().subscribe();
    });
  }

  private stopRenewTimer(): void {
    if (this.renewTimer) {
      this.renewTimer.unsubscribe();
      this.renewTimer = undefined;
    }
  }
}