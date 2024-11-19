import { TestBed } from '@angular/core/testing';

import { AssetsApiService } from './assets.api.service';

describe('AssetsApiService', () => {
  let service: AssetsApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AssetsApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
