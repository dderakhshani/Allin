import { Routes } from "@angular/router";
import { CreateUserPageComponent } from "./create-user/create-user-page.component";
import { UserListPageComponent } from "./user-list/user-list-page.component";


export const User_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "create",
        component: CreateUserPageComponent, data: {
            title: 'create user page'
        }
    },
    {
        path: "list",
        component: UserListPageComponent, data: {
            title: 'user list page'
        }
    },
];
