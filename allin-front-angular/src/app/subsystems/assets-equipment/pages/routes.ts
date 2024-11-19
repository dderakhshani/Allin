import { Routes } from "@angular/router";

export const ASSETS_ROOT_ROUTES: Routes = [
    {
        path: "dashboards",
                data: {
                    title: 'Items'
                },
                loadChildren: () => import('./dashboards/routes').then(mod => mod.DASHBOARD_ROUTES)
    },
];
