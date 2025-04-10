import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';

import { CoreFrontendModule } from 'core-frontend-package';
import { UiFrontendModule } from 'ui-frontend-package';
import { UgyfelEditorComponent } from './components/ugyfel-editor/ugyfel-editor.component';
import { UgyfelListComponent } from './components/ugyfel-list/ugyfel-list.component';

import { DxButtonModule } from 'devextreme-angular/ui/button';
import { DxDataGridModule } from 'devextreme-angular/ui/data-grid';
import { DxPopupModule } from 'devextreme-angular/ui/popup';
import { DxTextBoxModule } from 'devextreme-angular/ui/text-box';

@NgModule({
  declarations: [
    AppComponent,
    UgyfelEditorComponent,
    UgyfelListComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    CoreFrontendModule,
    UiFrontendModule,

    DxButtonModule,
    DxDataGridModule,
    DxPopupModule,
    DxTextBoxModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class UgyfelkezeloModule { }
