import { TestBed } from '@angular/core/testing';

import { UiFrontendPackageService } from './ui-frontend-package.service';

describe('UiFrontendPackageService', () => {
  let service: UiFrontendPackageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UiFrontendPackageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
