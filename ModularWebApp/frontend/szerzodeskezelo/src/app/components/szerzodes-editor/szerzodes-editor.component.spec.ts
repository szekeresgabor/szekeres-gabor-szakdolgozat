import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SzerzodesEditorComponent } from './szerzodes-editor.component';

describe('SzerzodesEditorComponent', () => {
  let component: SzerzodesEditorComponent;
  let fixture: ComponentFixture<SzerzodesEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SzerzodesEditorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SzerzodesEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
