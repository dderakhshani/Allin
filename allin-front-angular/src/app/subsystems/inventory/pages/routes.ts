import { Routes } from "@angular/router";

export const INVENTORY_ROOT_ROUTES: Routes = [
    {
        path: "items",
                data: {
                    title: 'Items'
                },
                loadChildren: () => import('./items/routes').then(mod => mod.ITEMS_ROUTES)
    },
    {
        path: "item-categories",
        data: {
            title: 'Item Category'
        },
        loadChildren: () => import('./item-categories/routes').then(mod => mod.ITEM_CATEGORY_ROUTES)
    },
];
