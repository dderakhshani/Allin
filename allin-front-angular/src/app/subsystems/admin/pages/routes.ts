import { Routes } from "@angular/router";

export const Admin_ROOT_ROUTES: Routes = [
    {
        path: "user",
                data: {
                    title: 'user'
                },
                loadChildren: () => import('./user/routes').then(mod => mod.User_ROUTES)
    },
    {
        path: "person",
                data: {
                    title: 'person'
                },
                loadChildren: () => import('./person/routes').then(mod => mod.Person_ROUTES)
    },
    {
        path: "employee",
                data: {
                    title: 'employee'
                },
                loadChildren: () => import('./employee/routes').then(mod => mod.Employee_ROUTES)
    },

];
