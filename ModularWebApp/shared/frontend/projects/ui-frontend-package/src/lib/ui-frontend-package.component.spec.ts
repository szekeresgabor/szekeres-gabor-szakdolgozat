import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UiFrontendPackageComponent } from './ui-frontend-package.component';

describe('UiFrontendPackageComponent', () => {
  let component: UiFrontendPackageComponent;
  let fixture: ComponentFixture<UiFrontendPackageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UiFrontendPackageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UiFrontendPackageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
