import { TestBed } from '@angular/core/testing';

import { ExtendedFieldsService } from './extended-fields.service';

describe('ExtendedFieldsService', () => {
  let service: ExtendedFieldsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExtendedFieldsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
