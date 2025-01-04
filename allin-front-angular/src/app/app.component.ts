import { Component } from '@angular/core';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { TranslatePipe, TranslateDirective, TranslateService } from '@ngx-translate/core';
import { PrimeNG } from 'primeng/config';
import { ToolbarModule } from 'primeng/toolbar';
import { BasicModule } from './core/basic.module';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { DrawerModule } from 'primeng/drawer';
import { TabsModule } from 'primeng/tabs';
import { MenuModule } from 'primeng/menu';
import { Menu } from 'primeng/menu';
import { BadgeModule } from 'primeng/badge';
import { OverlayBadgeModule } from 'primeng/overlaybadge';
import { AvatarModule } from 'primeng/avatar';
import { AvatarGroupModule } from 'primeng/avatargroup';
import { MenuComponent } from './layouts/menu/menu.component';
import { MenuItem } from 'primeng/api';
import { Ripple } from 'primeng/ripple';
import { ToggleSwitch } from 'primeng/toggleswitch';
import { DividerModule } from 'primeng/divider';
import { CommonModule } from '@angular/common';
import { TabNavigatorComponent } from "./layouts/tab-navigator/tab-navigator.component";

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [
        CommonModule,
        RouterModule,
        TranslatePipe,
        TranslateDirective,
        BasicModule,
        ToolbarModule,
        ToggleButtonModule,
        DrawerModule,
        TabsModule,
        MenuModule,
        BadgeModule,
        OverlayBadgeModule,
        AvatarModule,
        ToggleSwitch,
        MenuComponent,
        DividerModule,
        TabNavigatorComponent
    ],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss'
})
export class AppComponent {
    title = 'Allin';
    dark = false;
    isMobile = false;
    isCompact = false;
    mobileMenuVisible = false;


    menuItems: MenuItem[] = [
        {
            label: 'Home',
            icon: 'home',
            shortcut: '⌘+N',
            id: '1',
            routerLink: '/'
        },
        {
            label: 'Settings',
            icon: 'settings',
            shortcut: '⌘+N',
            items: [
                {
                    id: '2',
                    label: 'General',
                    icon: 'settings',
                    shortcut: '⌘+N',
                    routerLink: '/settings/general'
                },
                {
                    id: '3',
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
                    id: '3',
                    label: 'Add User',
                    icon: 'person_add',
                    shortcut: '⌘+N',
                    routerLink: '/admin/user/add'
                },
                {
                    id: '5',
                    label: 'Users List',
                    icon: 'group',
                    badge: '2',
                    routerLink: '/admin/user/list'
                },
            ],
        },
    ];

    constructor(private translate: TranslateService,
        private primeng: PrimeNG,
    ) {
        this.translate.addLangs(['de', 'en']);
        this.translate.setDefaultLang('en');
        this.translate.use('en');

        this.translate.get('primeng').subscribe(res => this.primeng.setTranslation(res));
    }

    ngOnInit() {
        this.checkScreenSize();
        window.addEventListener('resize', this.checkScreenSize.bind(this));
    }

    checkScreenSize() {
        this.isMobile = window.innerWidth < 768;
    }

    toggleDrawer() {
        if (this.isMobile)
            this.mobileMenuVisible = !this.mobileMenuVisible;
        else
            this.isCompact = !this.isCompact;
    }


    darkChanged(event: any) {
        const element = document.querySelector('html');
        element?.classList.toggle('dark');
    }

    openTab(item: MenuItem) {

    }
}
