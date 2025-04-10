import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PanaszDto } from '../generated/panaszkezelo-api';

@Injectable({ providedIn: 'root' })
export class PanaszService {
  private readonly baseUrl = 'http://localhost:5077/api/Panasz';

  constructor(private http: HttpClient) { }

  getAll(): Observable<PanaszDto[]> {
    return this.http.get<PanaszDto[]>(this.baseUrl);
  }

  getById(id: string): Observable<PanaszDto> {
    return this.http.get<PanaszDto>(`${this.baseUrl}/${id}`);
  }

  create(dto: PanaszDto): Observable<any> {
    return this.http.post(this.baseUrl, dto);
  }

  update(id: string, dto: PanaszDto): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}