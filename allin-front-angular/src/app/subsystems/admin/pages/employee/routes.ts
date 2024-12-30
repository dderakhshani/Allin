import { Routes } from "@angular/router";
import { AddEmployeePageComponent } from "./add-employee/add-employee-page.component";
import { EditEmployeePageComponent } from "./edit-employee/edit-employee-page.component";
import { EmployeeListPageComponent } from "./employee-list/employee-list-page.component";
 
export const Employee_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "add",
        component: AddEmployeePageComponent, data: {
            title: 'add employee'
        }
    },
    {
        path: "edit",
        component: EditEmployeePageComponent, data: {
            title: 'edit employee'
        }
    },
    {
        path: "list",
        component: EmployeeListPageComponent, data: {
            title: 'employee list'
        }
    },
];
