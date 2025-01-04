import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
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

@Component({
    selector: 'app-root',
    standalone: true,
    imports: [RouterOutlet,
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
    openedTabs: any[] = [];
    activeTab = '';

    menuItems: MenuItem[] = [
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
                    label: 'Add Employee',
                    icon: 'person_add',
                    shortcut: '⌘+N',
                    routerLink: '/admin/employee/add'
                },
            ],
        },
    ];

    constructor(private translate: TranslateService,
        private primeng: PrimeNG,
        private router: Router
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


    openTab(item: MenuItem) {
        const tabIndex = this.openedTabs.findIndex((tab) => tab.routerLink === item.routerLink);
        this.activeTab = item.routerLink;

        if (tabIndex === -1) {
            this.openedTabs.push(item);
        } else {
        }

        this.router.navigateByUrl(item.routerLink);
        this.mobileMenuVisible = false;
    }

    closeTab(tab: any, index: number) {
        this.openedTabs.splice(index, 1);

        if (this.openedTabs.length > 0) {
            // if (this.activeTabIndex >= index) {
            //     this.activeTabIndex = Math.max(0, this.activeTabIndex - 1);
            // }
            // this.router.navigateByUrl(this.openedTabs[this.activeTabIndex].route);
        } else {
            this.router.navigateByUrl('/');
        }
    }

    darkChanged(event: any) {
        const element = document.querySelector('html');
        element?.classList.toggle('dark');
    }
}
