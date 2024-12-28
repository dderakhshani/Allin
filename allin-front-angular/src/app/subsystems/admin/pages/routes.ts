import { Routes } from "@angular/router";

export const Admin_ROOT_ROUTES: Routes = [
    {
        path: "user",
                data: {
                    title: 'user'
                },
                loadChildren: () => import('./user/routes').then(mod => mod.User_ROUTES)
    },

];
