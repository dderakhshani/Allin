import { Routes } from "@angular/router";
import { BasevalueListPageComponent } from "./basevalue-list/basevalue-list-page.component";
import { EditBasevaluePageComponent } from "./edit-basevalue/edit-basevalue-page.component";
import { CreateBasevaluePageComponent } from "./create-basevalue/create-basevalue-page.component";

export const Basevalue_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "add",
        component: CreateBasevaluePageComponent, data: {
            title: 'add basevalue'
        }
    },
    {
        path: "edit",
        component: BasevalueListPageComponent, data: {
            title: 'edit basevalue'
        }
    },
    {
        path: "list",
        component: EditBasevaluePageComponent, data: {
            title: 'basevalue list'
        }
    },
];
