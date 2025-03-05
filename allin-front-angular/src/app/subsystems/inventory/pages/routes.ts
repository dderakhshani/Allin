import { Routes } from "@angular/router";

export const INVENTORY_ROOT_ROUTES: Routes = [
    {
        path: "packings",
        data: {
            title: 'Packings'
        },
        loadChildren: () => import('./packings/routes').then(mod => mod.PACKING_ROUTES)
    },
    {
        path: "categories",
        data: {
            title: 'Categories'
        },
        loadChildren: () => import('./categories/routes').then(mod => mod.CATEGORY_ROUTES)
    },
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
