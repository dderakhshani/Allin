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
                        label: 'Roles & Permission',
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
                        label: 'department',
                        icon: 'graph_2',
                        badge: '2',
                        routerLink: '/admin/department/list'
                    },

                    
                ],
            },
        ]
    }
}
