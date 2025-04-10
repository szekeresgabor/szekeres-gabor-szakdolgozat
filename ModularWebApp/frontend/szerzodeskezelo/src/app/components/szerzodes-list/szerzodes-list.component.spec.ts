import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SzerzodesListComponent } from './szerzodes-list.component';

describe('SzerzodesListComponent', () => {
  let component: SzerzodesListComponent;
  let fixture: ComponentFixture<SzerzodesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SzerzodesListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SzerzodesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
