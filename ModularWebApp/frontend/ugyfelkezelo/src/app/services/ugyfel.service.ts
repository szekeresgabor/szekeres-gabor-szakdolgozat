import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UgyfelDto } from '../generated/ugyfelkezelo-api';
import { UgyfelSharedService } from 'core-frontend-package';

@Injectable({
  providedIn: 'root'
})
export class UgyfelService extends UgyfelSharedService {
  constructor(http: HttpClient) { super(http); }

  getById(id: string): Observable<UgyfelDto> {
    return this.http.get<UgyfelDto>(`${this.baseUrl}/${id}`);
  }

  create(dto: UgyfelDto): Observable<any> {
    return this.http.post(this.baseUrl, dto);
  }

  update(id: string, dto: UgyfelDto): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}