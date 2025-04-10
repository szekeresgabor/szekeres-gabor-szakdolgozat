import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PanaszEditorComponent } from './panasz-editor.component';

describe('PanaszEditorComponent', () => {
  let component: PanaszEditorComponent;
  let fixture: ComponentFixture<PanaszEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PanaszEditorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PanaszEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
