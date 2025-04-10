import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginPopupComponent } from './components/login-popup/login-popup.component';
import { ErrorPopupComponent } from './components/error-popup/error-popup.component';
import { LayoutComponent } from './components/layout/layout.component';
import { FileUploaderComponent } from './components/file-uploader/file-uploader.component';
import { FormsModule } from '@angular/forms';


// Csak a szükséges DevExtreme modulok importálása
import { DxPopupModule } from 'devextreme-angular/ui/popup';
import { DxFileUploaderModule } from 'devextreme-angular/ui/file-uploader';
import { DxToolbarModule } from 'devextreme-angular/ui/toolbar';
import { DxMenuModule } from 'devextreme-angular/ui/menu';
import { DxTextBoxModule } from 'devextreme-angular/ui/text-box';
import { DxButtonModule } from 'devextreme-angular/ui/button';
import { DxValidatorModule } from 'devextreme-angular/ui/validator';

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
    DxFileUploaderModule,
    DxToolbarModule,
    DxMenuModule,
    DxTextBoxModule,
    DxButtonModule,
    DxValidatorModule,
    DxValidatorModule
  ],
  exports: [
    LoginPopupComponent,
    ErrorPopupComponent,
    LayoutComponent,
    FileUploaderComponent
  ]
})
export class UiFrontendModule { }