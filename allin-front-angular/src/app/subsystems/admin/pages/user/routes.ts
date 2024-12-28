import { Routes } from "@angular/router";
import { CreateUserComponent } from "./create-user/create-user.component";
import { ListUsersComponent } from "./list-users/list-users.component";
 
export const User_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "create-user",
        component: CreateUserComponent, data: {
            title: 'create user'
        }
    },
    {
        path: "list-user",
        component: ListUsersComponent, data: {
            title: 'list user'
        }
    },
];
