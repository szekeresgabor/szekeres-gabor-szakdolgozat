import { TestBed } from '@angular/core/testing';

import { UgyfelService } from './ugyfel.service';

describe('UgyfelService', () => {
  let service: UgyfelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UgyfelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
