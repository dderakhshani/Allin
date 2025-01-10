import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataTableFiltersHeaderComponent } from './data-table-filters-header.component';

describe('DataTableFiltersHeaderComponent', () => {
  let component: DataTableFiltersHeaderComponent;
  let fixture: ComponentFixture<DataTableFiltersHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DataTableFiltersHeaderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DataTableFiltersHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
