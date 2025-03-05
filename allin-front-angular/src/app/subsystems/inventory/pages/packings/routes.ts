import { Routes } from "@angular/router";
import { CreatePackingPageComponent } from "./create-packing/create-packing-page.component";
import { EditPackingPageComponent } from "./edit-packing/edit-packing-page.component";
import { PackingListPageComponent } from "./packing-list/packing-list-page.component";



export const PACKING_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "create",
        component: CreatePackingPageComponent, data: {
            title: 'Create Packing'
        }
    },
    {
        path: "edit",
        component: EditPackingPageComponent, data: {
            title: 'edit Packing'
        }
    },
    {
        path: "list",
        component: PackingListPageComponent, data: {
            title: 'Packings List'
        }
    },
];
