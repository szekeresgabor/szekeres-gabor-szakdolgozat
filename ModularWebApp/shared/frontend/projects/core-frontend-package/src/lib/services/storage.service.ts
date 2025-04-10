import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class StorageService {
  private readonly baseUrl = 'http://localhost:5102/api/files';

  constructor(private http: HttpClient) { }

  /**
   * Fájl letöltése azonosító alapján (GUID)
   */
  downloadFile(id: string): Observable<Blob> {
    return this.http.get(`${this.baseUrl}/${id}`, { responseType: 'blob' });
  }

  /**
   * Fájl feltöltése (multipart/form-data)
   */
  uploadFile(file: File): Observable<HttpEvent<any>> {
    const formData = new FormData();
    formData.append('file', file);

    const req = new HttpRequest('POST', `${this.baseUrl}/upload`, formData, {
      reportProgress: true
    });

    return this.http.request(req);
  }

  /**
   * Fájl törlése
   */
  deleteFile(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }

  /**
   * Fájl név lekérdezése
   */
  getFileName(id: string): Observable<string> {
    return this.http.get(`${this.baseUrl}/name/${id}`, {
      responseType: 'text'
    });
  }
}