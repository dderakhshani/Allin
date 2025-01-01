import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { TranslatePipe, TranslateDirective, TranslateService } from '@ngx-translate/core';
import { PrimeNG } from 'primeng/config';
import { ToolbarModule } from 'primeng/toolbar';
import { BasicModule } from './core/basic.module';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { DrawerModule } from 'primeng/drawer';
import { TabsModule } from 'primeng/tabs';

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
        TabsModule
    ],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss'
})
export class AppComponent {
    title = 'Allin';
    dark = true;
    isMobile = false;
    isCompact = false;
    mobileMenuVisible = false;
    openedTabs: any[] = [];
    activeTabIndex = 0;

    menuItems = [
        { label: 'Home', icon: 'pi pi-home', route: 'home' },
        { label: 'Settings', icon: 'pi pi-cog', route: 'SettingsComponent' },
        { label: 'User List', icon: 'pi pi-user', route: 'admin/user/list' },
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
        this.mobileMenuVisible = !this.mobileMenuVisible;
    }

    openTab(item: any) {
        const tabIndex = this.openedTabs.findIndex((tab) => tab.route === item.route);

        if (tabIndex === -1) {
            this.openedTabs.push(item);
            this.activeTabIndex = this.openedTabs.length - 1;
        } else {
            this.activeTabIndex = tabIndex;
        }

        this.router.navigateByUrl(item.route);
        this.mobileMenuVisible = false;
    }

    closeTab(tab: any, index: number) {
        this.openedTabs.splice(index, 1);

        if (this.openedTabs.length > 0) {
            if (this.activeTabIndex >= index) {
                this.activeTabIndex = Math.max(0, this.activeTabIndex - 1);
            }
            this.router.navigateByUrl(this.openedTabs[this.activeTabIndex].route);
        } else {
            this.router.navigateByUrl('/');
        }
    }

    darkChanged(event: any) {
        const element = document.querySelector('html');
        element?.classList.toggle('dark-mode');
    }
}
