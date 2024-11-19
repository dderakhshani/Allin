import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateItemCategoryComponent } from './create-item-category.component';

describe('CreateItemCategoryComponent', () => {
  let component: CreateItemCategoryComponent;
  let fixture: ComponentFixture<CreateItemCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateItemCategoryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateItemCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
