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
import { MenuService } from './core/services/menu.service';

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
        Ripple
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

    menuItems: MenuItem[] = [];

    constructor(private translate: TranslateService,
        private primeng: PrimeNG,
        private router: Router,
        private menuService: MenuService,
    ) {
        this.translate.addLangs(['de', 'en']);
        this.translate.setDefaultLang('en');
        this.translate.use('en');

        this.translate.get('primeng').subscribe(res => this.primeng.setTranslation(res));
        this.menuItems = this.menuService.getAll();
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
