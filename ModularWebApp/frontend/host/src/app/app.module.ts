import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { CoreFrontendModule, ErrorService } from 'core-frontend-package';
import { UiFrontendModule } from 'ui-frontend-package';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreFrontendModule,
    UiFrontendModule
  ],
  providers: [
    { provide: ErrorHandler, useClass: ErrorService }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
