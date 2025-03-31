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
    {
        path: "baseValue",
        data: {
            title: 'baseValue'
        },
        loadChildren: () => import('./baseValue/routes').then(mod => mod.Basevalue_ROUTES)
    },
    {
        path: "role",
        data: {
            title: 'role'
        },
        loadChildren: () => import('./role/routes').then(mod => mod.Role_ROUTES)
    },
    {
        path: "department",
        data: {
            title: 'department'
        },
        loadChildren: () => import('./department/routes').then(mod => mod.Department_ROUTES)
    },
    {
        path: "position",
        data: {
            title: 'position'
        },
        loadChildren: () => import('./position/routes').then(mod => mod.Position_ROUTES)
    },
    {
        path: "place",
        data: {
            title: 'place'
        },
        loadChildren: () => import('./place/routes').then(mod => mod.Place_ROUTES)
    },
    {
        path: "extendedfield",
        data: {
            title: 'extendedfield'
        },
        loadChildren: () => import('./extended-field/routes').then(mod => mod.ExtendedField_ROUTES)
    },
    {
        path: "team",
        data: {
            title: 'team'
        },
        loadChildren: () => import('./team/routes').then(mod => mod.Team_ROUTES)
    },

];
