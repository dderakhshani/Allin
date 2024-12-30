import { Routes } from "@angular/router";
import { AddBasevaluePageComponent } from "./add-basevalue/add-basevalue-page.component";
import { BasevalueListPageComponent } from "./basevalue-list/basevalue-list-page.component";
import { EditBasevaluePageComponent } from "./edit-basevalue/edit-basevalue-page.component";

export const Basevalue_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "add",
        component: AddBasevaluePageComponent, data: {
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
