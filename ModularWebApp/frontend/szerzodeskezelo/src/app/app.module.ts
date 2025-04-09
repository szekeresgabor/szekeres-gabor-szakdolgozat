import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';

import { CoreFrontendModule } from 'core-frontend-package';
import { UiFrontendModule } from 'ui-frontend-package';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    CoreFrontendModule,
    UiFrontendModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class SzerzodeskezeloModule { }
