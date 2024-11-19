import { Routes } from "@angular/router";
import { EquipmentMonitoringDashboardComponent } from "./monitoring-dashboard/equipment-monitoring-dashboard.component";
import { EquipmentOperationHistoryComponent } from "./operation-history/equipment-operation-history.component";

export const DASHBOARD_ROUTES: Routes = [
    {
        path: "monitoring",
        component: EquipmentMonitoringDashboardComponent,
                data: {
                    title: 'Equipment Monitoring'
                }
    },
    {
        path: "operation",
        component: EquipmentOperationHistoryComponent,
        data: {
            title: 'Operation History'
        }
    },
];
