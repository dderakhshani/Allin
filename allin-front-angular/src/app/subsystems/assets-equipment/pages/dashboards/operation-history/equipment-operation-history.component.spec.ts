import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipmentOperationHistoryComponent } from './equipment-operation-history.component';

describe('EquipmentOperationHistoryComponent', () => {
  let component: EquipmentOperationHistoryComponent;
  let fixture: ComponentFixture<EquipmentOperationHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EquipmentOperationHistoryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EquipmentOperationHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
