import { animate, style, transition, trigger } from '@angular/animations';
import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { BadgeModule } from 'primeng/badge';
type MenuItemOpenable = MenuItem & { isOpen: boolean };

@Component({
    selector: 'app-menu',
    standalone: true,
    imports: [CommonModule,
        BadgeModule,
    ],
    templateUrl: './menu.component.html',
    styleUrl: './menu.component.scss',
    animations: [
        trigger('slideInFade', [
            transition(':enter', [
                style({ opacity: 0.3, transform: 'translateX(-100px)' }),
                animate('200ms ease-out', style({ opacity: 1, transform: 'translateX(0)' })),
            ]),
            transition(':leave', [
                animate('200ms ease-in', style({ opacity: 0, transform: 'translateX(-100px)' })),
            ]),
        ]),
    ],
})
export class MenuComponent {

    _menuItems: MenuItemOpenable[] = [];

    @Input()
    set menuItems(value: MenuItem[]) {
        this._menuItems = value.map(x => ({ ...x, isOpen: false }));
    }

    @Input()
    compact: boolean = false;

    @Output()
    onItemSelected = new EventEmitter<MenuItem>();


    selectedLastMenu: MenuItem | null = null;
    oldSelectedMenu: MenuItemOpenable | null = null;

    onMenuItemClick(menuItem: MenuItemOpenable, event: any): void {
        if (menuItem.items && menuItem.items.length > 0) {
            const target = event.currentTarget as HTMLElement;
            const rect = target.getBoundingClientRect();
            // this.submenuLeft = `${rect.right}px`;
            //
            if (this.oldSelectedMenu)
                this.toggleMenu(this.oldSelectedMenu);

            this.toggleMenu(menuItem);
        } else {
            this.selectedLastMenu = menuItem;
            this.closeAllMenus(this._menuItems);
            this.onItemSelected.emit(menuItem);
        }
        this.oldSelectedMenu = menuItem;
    }

    toggleMenu(item: MenuItemOpenable): void {
        if (item.items) {
            item.isOpen = !item.isOpen; // Toggle the open state
        }
    }

    closeAllMenus(menu: MenuItemOpenable[]): void {
        for (const item of menu) {
            item.isOpen = false;
            if (item.items) {
                this.closeAllMenus(item.items as any);
            }
        }
    }
}
