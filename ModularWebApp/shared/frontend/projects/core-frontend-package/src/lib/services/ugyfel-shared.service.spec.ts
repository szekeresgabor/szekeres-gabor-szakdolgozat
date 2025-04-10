import { TestBed } from '@angular/core/testing';

import { UgyfelSharedService } from './ugyfel-shared.service';

describe('UgyfelSharedService', () => {
  let service: UgyfelSharedService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UgyfelSharedService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
