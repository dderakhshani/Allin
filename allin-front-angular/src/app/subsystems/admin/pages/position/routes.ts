import { Routes } from "@angular/router";
import { CreatePositionPageComponent } from "./create-position/create-position-page.component";
import { EditPositionPageComponent } from "./edit-position/edit-position-page.component";
import { PositionListPageComponent } from "./position-list/position-list-page.component";


export const Position_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "add",
        component: CreatePositionPageComponent, data: {
            title: 'add position'
        }
    },
    {
        path: "edit",
        component: EditPositionPageComponent, data: {
            title: 'edit position'
        }
    },
    {
        path: "list",
        component: PositionListPageComponent, data: {
            title: 'position list'
        }
    },
];
