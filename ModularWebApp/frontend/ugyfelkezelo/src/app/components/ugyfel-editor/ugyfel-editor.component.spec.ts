import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UgyfelEditorComponent } from './ugyfel-editor.component';

describe('UgyfelEditorComponent', () => {
  let component: UgyfelEditorComponent;
  let fixture: ComponentFixture<UgyfelEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UgyfelEditorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UgyfelEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
