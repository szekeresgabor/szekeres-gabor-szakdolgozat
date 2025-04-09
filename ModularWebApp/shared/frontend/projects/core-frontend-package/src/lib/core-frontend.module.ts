import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ElasticInterceptor } from './interceptors/elastic.interceptor';
import { JwtInterceptor } from './interceptors/jwt.interceptor';

@NgModule({
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ElasticInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  imports: [HttpClientModule]
})
export class CoreFrontendModule { }
