import { TestBed } from '@angular/core/testing';

import { ExtendedfieldService } from './extendedfield.service';

describe('ExtendedfieldService', () => {
  let service: ExtendedfieldService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExtendedfieldService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
