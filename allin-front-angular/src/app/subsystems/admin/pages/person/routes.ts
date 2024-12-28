import { Routes } from "@angular/router";
import { AddPersonPageComponent } from "./add-person/add-person-page.component";
import { EditPersonPageComponent } from "./edit-person/edit-person-page.component";
import { PersonListPageComponent } from "./person-list/person-list-page.component";

 
export const Person_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "add-person",
        component: AddPersonPageComponent, data: {
            title: 'add person'
        }
    },
    {
        path: "edit-person",
        component: EditPersonPageComponent, data: {
            title: 'edit person'
        }
    },
    {
        path: "person-list",
        component: PersonListPageComponent, data: {
            title: 'person list'
        }
    },
];
