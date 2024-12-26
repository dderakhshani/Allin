import { TestBed } from '@angular/core/testing';

import { ItemCategoryApiService } from './item-category-api.service';

describe('ItemCategoryApiService', () => {
  let service: ItemCategoryApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ItemCategoryApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
