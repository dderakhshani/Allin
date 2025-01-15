import { TestBed } from '@angular/core/testing';

import { BasevalueService } from './basevalue.service';

describe('BasevalueService', () => {
  let service: BasevalueService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BasevalueService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
