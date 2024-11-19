import { Routes } from "@angular/router";
import { CreateItemComponent } from "./create/create-item.component";
import { ItemsListComponent } from "./list/items-list.component";

export const ITEMS_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "create",
        component: CreateItemComponent, 
        data: {
            title: 'Create Item'
        }
    },
    {
        path: "list",
        component: ItemsListComponent, 
        data: {
            title: 'Items List'
        }
    },
];
