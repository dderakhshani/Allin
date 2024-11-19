import { Routes } from "@angular/router";
import { CreateItemCategoryComponent } from "./create/create-item-category.component";
import { ItemCategoriesListComponent } from "./list/item-categories-list.component";

export const ITEM_CATEGORY_ROUTES: Routes = [
    {
        path: "",
        redirectTo: "list",
        pathMatch: "full"
    },
    {
        path: "create",
        component: CreateItemCategoryComponent, data: {
            title: 'Create Category'
        }
    },
    {
        path: "list",
        component: ItemCategoriesListComponent, data: {
            title: 'Categories List'
        }
    },
];
