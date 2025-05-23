import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class MenuService {

    constructor() { }

    getAll() {
        return [
            {
                label: 'Home',
                icon: 'home',
                shortcut: '⌘+N',
                routerLink: '/'
            },
            {
                label: 'Settings',
                icon: 'settings',
                shortcut: '⌘+N',
                items: [
                    {
                        label: 'General',
                        icon: 'settings',
                        shortcut: '⌘+N',
                        routerLink: '/settings/security'
                    },
                    {
                        label: 'Security',
                        icon: 'admin_panel_settings',
                        shortcut: '⌘+N',
                        routerLink: '/settings/security'
                    },
                ],
            },
            {
                label: 'Administration',
                icon: 'shield_person',
                items: [
                    {
                        label: 'Persons',
                        icon: 'group',
                        shortcut: '⌘+N',
                        routerLink: '/admin/person/list'
                    },
                    {
                        label: 'Employees',
                        icon: 'badge',
                        shortcut: '⌘+N',
                        routerLink: '/admin/employee/list'
                    },
                    {
                        label: 'Roles & Permissions',
                        icon: 'admin_panel_settings',
                        shortcut: '⌘+N',
                        routerLink: '/admin/role/list'
                    },
                    {
                        label: 'Users',
                        icon: 'account_circle',
                        badge: '2',
                        routerLink: '/admin/user/list'
                    },
                    {
                        label: 'Departments',
                        icon: 'graph_2',
                        badge: '2',
                        routerLink: '/admin/department/list'
                    },

                    {
                        label: 'Positions',
                        icon: 'diversity_3',
                        badge: '2',
                        routerLink: '/admin/position/list'
                    },
                    {
                        label: 'Places',
                        icon: 'location_on',
                        badge: '2',
                        routerLink: '/admin/place/list'
                    },
                    {
                        label: 'Base Values',
                        icon: 'token',
                        badge: '2',
                        routerLink: '/admin/baseValue/list'
                    },
                    {
                        label: 'Extended Fields',
                        icon: 'splitscreen_add',
                        badge: '2',
                        routerLink: '/admin/extendedfield/list'
                    },
                    {
                        label: 'Teams',
                        icon: 'groups',
                        badge: '2',
                        routerLink: '/admin/team/list'
                    },


                ],
            },
            {
                label: 'Inventory',
                icon: 'inventory_2',
                shortcut: '⌘+N',
                items: [
                    {
                        label: 'Packings',
                        icon: 'package_2',
                        shortcut: '⌘+N',
                        routerLink: '/inventory/packings/list'
                    },
                    {
                        label: 'Categories',
                        icon: 'category',
                        shortcut: '⌘+N',
                        routerLink: '/inventory/categories/list'
                    },
                    {
                        label: 'Products',
                        icon: 'conveyor_belt',
                        shortcut: '⌘+N',
                        routerLink: '/settings/security'
                    },
                ],
            },
        ]
    }
}
