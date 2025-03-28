import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CoreFrontendPackageComponent } from './core-frontend-package.component';

describe('CoreFrontendPackageComponent', () => {
  let component: CoreFrontendPackageComponent;
  let fixture: ComponentFixture<CoreFrontendPackageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CoreFrontendPackageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CoreFrontendPackageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
