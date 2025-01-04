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
                label: 'Users',
                icon: 'account_circle',
                items: [
                    {
                        label: 'Add User',
                        icon: 'person_add',
                        shortcut: '⌘+N',
                        routerLink: '/admin/user/add'
                    },
                    {
                        label: 'Users List',
                        icon: 'group',
                        badge: '2',
                        routerLink: '/admin/user/list'
                    },
                    {
                        label: 'Add Person',
                        icon: 'person_add',
                        shortcut: '⌘+N',
                        routerLink: '/admin/person/add'
                    },
                    {
                        label: 'Employees',
                        icon: 'badge',
                        shortcut: '⌘+N',
                        routerLink: '/admin/employee/list'
                    },
                ],
            },
        ]
    }
}
