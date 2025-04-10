import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SzerzodesDto } from '../generated/szerzodeskezelo-api';

@Injectable({
  providedIn: 'root'
})
export class SzerzodesService {
  private readonly baseUrl = 'http://localhost:5078/api/Szerzodes';

  constructor(private http: HttpClient) { }

  getAll(): Observable<SzerzodesDto[]> {
    return this.http.get<SzerzodesDto[]>(this.baseUrl);
  }

  getById(id: string): Observable<SzerzodesDto> {
    return this.http.get<SzerzodesDto>(`${this.baseUrl}/${id}`);
  }

  create(dto: SzerzodesDto): Observable<any> {
    return this.http.post(this.baseUrl, dto);
  }

  update(id: string, dto: SzerzodesDto): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, dto);
  }

  delete(id: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}