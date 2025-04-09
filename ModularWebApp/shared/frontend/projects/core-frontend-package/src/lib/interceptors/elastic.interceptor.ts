// elastic.interceptor.ts
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class ElasticInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const correlationId = crypto.randomUUID();
    const modifiedReq = req.clone({
      setHeaders: {
        'X-CorrelationID': correlationId
      }
    });
    return next.handle(modifiedReq);
  }
}