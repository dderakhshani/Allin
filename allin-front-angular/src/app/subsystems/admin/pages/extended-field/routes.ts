import { Routes } from "@angular/router";
import { CreateExtendedFieldPageComponent } from "./create-extended-field/create-extended-field-page.component";
import { EditExtendedFieldPageComponent } from "./edit-extended-field/edit-extended-field-page.component";
import { ExtendedFieldListPageComponent } from "./extended-field-list/extended-field-list-page.component";


export const ExtendedField_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "add",
        component: CreateExtendedFieldPageComponent, data: {
            title: 'add extended field'
        }
    },
    {
        path: "edit",
        component: EditExtendedFieldPageComponent, data: {
            title: 'edit extended field'
        }
    },
    {
        path: "list",
        component: ExtendedFieldListPageComponent, data: {
            title: 'extended field list'
        }
    },
];
