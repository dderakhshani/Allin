import { Routes } from "@angular/router";
import { CreateDepartmentPageComponent } from "./create-department/create-department-page.component";
import { EditDepartmentPageComponent } from "./edit-department/edit-department-page.component";
import { DepartmentListPageComponent } from "./department-list/department-list-page.component";

 
export const Department_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "add",
        component: CreateDepartmentPageComponent, data: {
            title: 'add department'
        }
    },
    {
        path: "edit",
        component: EditDepartmentPageComponent, data: {
            title: 'edit department'
        }
    },
    {
        path: "list",
        component: DepartmentListPageComponent, data: {
            title: 'departments list'
        }
    },
];
