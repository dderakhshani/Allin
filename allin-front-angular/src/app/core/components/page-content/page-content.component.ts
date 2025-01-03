import { Component, Input } from '@angular/core';
import { BasicModule } from '../../basic.module';
import { ToolbarModule } from 'primeng/toolbar';
import { ProgressBar } from 'primeng/progressbar';

@Component({
    selector: 'app-page-content',
    standalone: true,
    imports: [
        BasicModule,
        ToolbarModule,
        ProgressBar
    ],
    templateUrl: './page-content.component.html',
    styleUrl: './page-content.component.scss'
})
export class PageContentComponent {

    @Input()
    isLoading = false;
}
