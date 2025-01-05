import { Routes } from "@angular/router";
import { CreateRolePageComponent } from "./create-role/create-role-page.component";
import { EditRolePageComponent } from "./edit-role/edit-role-page.component";
import { RoleListPageComponent } from "./role-list/role-list-page.component";

 
export const Role_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "add",
        component: CreateRolePageComponent, data: {
            title: 'add role'
        }
    },
    {
        path: "edit",
        component: EditRolePageComponent, data: {
            title: 'edit role'
        }
    },
    {
        path: "list",
        component: RoleListPageComponent, data: {
            title: 'role list'
        }
    },
];
