import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, interval, Observable, Subscription } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { LoginRequest } from '../generated/identity-api';

@Injectable({ providedIn: 'root' })
export class IdentityService {
  private readonly baseUrl = 'http://localhost:5096/api/Auth';
  private tokenKey = 'jwt-token';
  private renewTimer?: Subscription;

  private rolesSubject = new BehaviorSubject<string[]>([]);
  private permissionsSubject = new BehaviorSubject<string[]>([]);

  public roles$: Observable<string[]> = this.rolesSubject.asObservable();
  public permissions$: Observable<string[]> = this.permissionsSubject.asObservable();

  private usernameSubject = new BehaviorSubject<string | null>(null);
  public username$ = this.usernameSubject.asObservable();

  constructor(private http: HttpClient) {
    const existingToken = this.getToken();
    if (existingToken && this.isTokenValid(existingToken)) {
      this.updateClaimsFromToken(existingToken);
      this.startRenewTimer();
    } else {
      this.logout();
    }
  }

  login(data: LoginRequest): Observable<string> {
    return this.http.post<{ token: string }>(this.baseUrl + '/login', data).pipe(
      tap(response => {
        this.setToken(response.token);
        this.startRenewTimer();
      }),
      map(response => response.token)
    );
  }

  renew(): Observable<string> {
    return this.http.post<{ token: string }>(this.baseUrl + '/renew', {}).pipe(
      tap(response => this.setToken(response.token)),
      map(response => response.token)
    );
  }

  private setToken(token: string): void {
    localStorage.setItem(this.tokenKey, token);
    this.updateClaimsFromToken(token);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey);
    this.rolesSubject.next([]);
    this.permissionsSubject.next([]);
    this.usernameSubject.next(null);
    this.stopRenewTimer();
  }

  private isTokenValid(token: string): boolean {
    try {
      const payload = token.split('.')[1];
      const decoded = JSON.parse(atob(payload));

      const exp = decoded['exp'];
      if (!exp) return false;

      const now = Math.floor(Date.now() / 1000);
      return exp > now;
    } catch {
      return false;
    }
  }

  private updateClaimsFromToken(token: string): void {
    try {
      const payload = token.split('.')[1];
      const decoded = JSON.parse(atob(payload));

      const rawRoles = decoded['roles'];
      const rawPermissions = decoded['permissions'];
      const username = decoded['name'] ?? decoded['username'] ?? null;

      const roles = Array.isArray(rawRoles) ? rawRoles : rawRoles ? [rawRoles] : [];
      const permissions = Array.isArray(rawPermissions) ? rawPermissions : rawPermissions ? [rawPermissions] : [];

      this.rolesSubject.next(roles);
      this.permissionsSubject.next(permissions);
      this.usernameSubject.next(username);
    } catch {
      this.rolesSubject.next([]);
      this.permissionsSubject.next([]);
      this.usernameSubject.next(null);
    }
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