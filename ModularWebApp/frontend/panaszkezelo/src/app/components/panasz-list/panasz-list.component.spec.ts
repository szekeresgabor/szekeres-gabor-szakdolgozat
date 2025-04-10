import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PanaszListComponent } from './panasz-list.component';

describe('PanaszListComponent', () => {
  let component: PanaszListComponent;
  let fixture: ComponentFixture<PanaszListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PanaszListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PanaszListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
