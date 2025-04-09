import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DxPopupModule, DxFileUploaderModule } from 'devextreme-angular';

import { LoginPopupComponent } from './components/login-popup/login-popup.component';
import { ErrorPopupComponent } from './components/error-popup/error-popup.component';
import { LayoutComponent } from './components/layout/layout.component';
import { FileUploaderComponent } from './components/file-uploader/file-uploader.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    LoginPopupComponent,
    ErrorPopupComponent,
    LayoutComponent,
    FileUploaderComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    DxPopupModule,
    DxFileUploaderModule
  ],
  exports: [
    LoginPopupComponent,
    ErrorPopupComponent,
    LayoutComponent,
    FileUploaderComponent
  ]
})
export class UiFrontendModule { }