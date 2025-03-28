import { TestBed } from '@angular/core/testing';

import { CoreFrontendPackageService } from './core-frontend-package.service';

describe('CoreFrontendPackageService', () => {
  let service: CoreFrontendPackageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CoreFrontendPackageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
