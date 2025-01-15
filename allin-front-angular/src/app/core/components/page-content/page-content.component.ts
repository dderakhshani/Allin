import { Component, Input } from '@angular/core';
import { BasicModule } from '../../basic.module';
import { ToolbarModule } from 'primeng/toolbar';
import { ProgressBar } from 'primeng/progressbar';
import { BlockUI } from 'primeng/blockui';

@Component({
    selector: 'app-page-content',
    standalone: true,
    imports: [
        BasicModule,
        ToolbarModule,
        ProgressBar,
        BlockUI
    ],
    templateUrl: './page-content.component.html',
    styleUrl: './page-content.component.scss'
})
export class PageContentComponent {

    @Input()
    isLoading = false;

    @Input()
    blockUI = false;
}
