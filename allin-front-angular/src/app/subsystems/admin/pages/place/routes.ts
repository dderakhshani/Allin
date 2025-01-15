import { Routes } from "@angular/router";
import { CreatePlacePageComponent } from "./create-place/create-place-page.component";
import { EditPlacePageComponent } from "./edit-place/edit-place-page.component";
import { PlaceListPageComponent } from "./place-list/place-list-page.component";

export const Place_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "add",
        component: CreatePlacePageComponent, data: {
            title: 'add plase'
        }
    },
    {
        path: "edit",
        component: EditPlacePageComponent, data: {
            title: 'edit plase'
        }
    },
    {
        path: "list",
        component: PlaceListPageComponent, data: {
            title: 'place list'
        }
    },
];
