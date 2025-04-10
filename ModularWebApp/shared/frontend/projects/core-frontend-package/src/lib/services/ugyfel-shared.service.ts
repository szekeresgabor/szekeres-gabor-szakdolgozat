import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


export interface UgyfelSharedDto {
  id: string;
  nev: string;
  email: string;
  telefonszam: string;
}

@Injectable({
  providedIn: 'root'
})
@Injectable({ providedIn: 'root' })
export class UgyfelSharedService {
  protected readonly baseUrl = 'http://localhost:5001/api/Ugyfel';

  constructor(protected http: HttpClient) { }

  getAll(): Observable<UgyfelSharedDto[]> {
    return this.http.get<UgyfelSharedDto[]>(this.baseUrl);
  }
}