import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PngTableComponent } from './png-table.component';

describe('PngTableComponent', () => {
  let component: PngTableComponent;
  let fixture: ComponentFixture<PngTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PngTableComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PngTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
