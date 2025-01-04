import { Component } from '@angular/core';
import { BasicModule } from '../../core/basic.module';
import { Router, RouterModule } from '@angular/router';
import { TabsModule } from 'primeng/tabs';
import { MenuItem } from 'primeng/api';

@Component({
    selector: 'app-tab-navigator',
    standalone: true,
    imports: [
        BasicModule,
        RouterModule,
        TabsModule,
    ],
    templateUrl: './tab-navigator.component.html',
    styleUrl: './tab-navigator.component.scss'
})
export class TabNavigatorComponent {
    openedTabs: MenuItem[] = [];
    activeTab = '';


    constructor(
        private router: Router
    ) {

    }

    openTab(item: MenuItem) {
        const tabIndex = this.openedTabs.findIndex((tab) => tab.routerLink === item.routerLink);
        this.activeTab = item.routerLink;

        if (tabIndex === -1) {
            this.openedTabs.push(item);
        } else {
        }

        this.router.navigate([{ outlets: { [item.id!]: [item.routerLink] } }]);
    }

    closeTab(tab: MenuItem) {
        const index = this.openedTabs.indexOf(tab);

        this.openedTabs.splice(index, 1);

        if (this.openedTabs.length > 0) {
            //If current page is closed
            if (this.activeTab == tab.routerLink) {
                let activeTabIndex = this.openedTabs.length - 1;//go to last page by default
                if (index < this.openedTabs.length)//if current closed page was not last page; go to next page
                    activeTabIndex = index;
                this.router.navigateByUrl(this.openedTabs[activeTabIndex].routerLink);
            }
        } else {
            this.router.navigateByUrl('/');
        }
    }

}
