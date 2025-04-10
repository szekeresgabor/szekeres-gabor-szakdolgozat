import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';

import { CoreFrontendModule } from 'core-frontend-package';
import { UiFrontendModule } from 'ui-frontend-package';
import { PanaszListComponent } from './components/panasz-list/panasz-list.component';
import { PanaszEditorComponent } from './components/panasz-editor/panasz-editor.component';

import { DxButtonModule } from 'devextreme-angular/ui/button';
import { DxDataGridModule } from 'devextreme-angular/ui/data-grid';
import { DxPopupModule } from 'devextreme-angular/ui/popup';
import { DxTextBoxModule } from 'devextreme-angular/ui/text-box';
import { DxTextAreaModule } from 'devextreme-angular/ui/text-area';
import { DxDateBoxModule } from 'devextreme-angular/ui/date-box';
import { DxSelectBoxModule } from 'devextreme-angular/ui/select-box';

@NgModule({
  declarations: [
    AppComponent,
    PanaszListComponent,
    PanaszEditorComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    CoreFrontendModule,
    UiFrontendModule,

    DxButtonModule,
    DxDataGridModule,
    DxPopupModule,
    DxTextBoxModule,
    DxTextAreaModule,
    DxDateBoxModule,
    DxSelectBoxModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class PanaszkezeloModule { }
