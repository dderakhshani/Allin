import { Routes } from "@angular/router";
import { CategoryListPageComponent } from "./category-list/category-list-page.component";
import { EditCategoryPageComponent } from "./edit-category/edit-category-page.component";
import { CreateCategoryPageComponent } from "./create-category/create-category-page.component";


export const CATEGORY_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "create",
        component: CreateCategoryPageComponent, data: {
            title: 'Create Category'
        }
    },
    {
        path: "edit",
        component: EditCategoryPageComponent, data: {
            title: 'edit Category'
        }
    },
    {
        path: "list",
        component: CategoryListPageComponent, data: {
            title: 'Categories List'
        }
    },
];
