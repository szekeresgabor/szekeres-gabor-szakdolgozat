import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UgyfelListComponent } from './ugyfel-list.component';

describe('UgyfelListComponent', () => {
  let component: UgyfelListComponent;
  let fixture: ComponentFixture<UgyfelListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UgyfelListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UgyfelListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
