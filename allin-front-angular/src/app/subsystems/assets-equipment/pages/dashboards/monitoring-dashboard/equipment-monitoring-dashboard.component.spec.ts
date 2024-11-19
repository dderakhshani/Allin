import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipmentMonitoringDashboardComponent } from './equipment-monitoring-dashboard.component';

describe('EquipmentMonitoringDashboardComponent', () => {
  let component: EquipmentMonitoringDashboardComponent;
  let fixture: ComponentFixture<EquipmentMonitoringDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EquipmentMonitoringDashboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EquipmentMonitoringDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
