import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: 'auth', loadChildren: () => import('./subsystems/auth/pages/routes').then(m => m.AUTH_ROOT_ROUTES) },   
    { path: 'assets', loadChildren: () => import('./subsystems/assets-equipment/pages/routes').then(m => m.ASSETS_ROOT_ROUTES) },   
    { path: 'cmms', loadChildren: () => import('./subsystems/cmms/pages/routes').then(m => m.CMMS_ROOT_ROUTES) },   
    { path: 'inventory', loadChildren: () => import('./subsystems/inventory/pages/routes').then(m => m.INVENTORY_ROOT_ROUTES) },   
    { path: 'admin', loadChildren: () => import('./subsystems/admin/pages/routes').then(m => m.Admin_ROOT_ROUTES) },  
];
