import { TestBed } from '@angular/core/testing';

import { PanaszService } from './panasz.service';

describe('PanaszService', () => {
  let service: PanaszService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PanaszService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
