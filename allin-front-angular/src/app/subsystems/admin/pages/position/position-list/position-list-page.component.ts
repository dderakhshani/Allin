import { Component } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { ToolbarModule } from 'primeng/toolbar';
import { SelectButton } from 'primeng/selectbutton';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { PositionModel } from '../../../models/queries/position-model';
import { TreeNode } from 'primeng/api';
import { PositionChartComponent } from './chart/position-chart.component';
import { PositionGridComponent } from './grid/position-grid.component';
import { PositionService } from '../../../apis/position.service';
import { openDialog, PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { openConfirmDeleteDialog } from '../../../../../core/components/confirm-dialog/confirm-dialog.component';
import { finalize } from 'rxjs';
import { CreatePositionPageComponent } from '../create-position/create-position-page.component';
import { EditPositionPageComponent } from '../edit-position/edit-position-page.component';

@Component({
    selector: 'app-position-list-page',
    standalone: true,
    imports: [BasicModule,
        ToolbarModule,
        SelectButton,
        PositionChartComponent,
        PositionGridComponent
    ],
    providers: [DialogService],
    templateUrl: './position-list-page.component.html',
    styleUrl: './position-list-page.component.scss'
})
export class PositionListPageComponent {

    isLoading = false;

    stateOptions: any[] = [
        { label: 'Chart', value: 'chart', icon: 'pi pi-sitemap' },
        { label: 'Grid', value: 'grid', icon: 'pi pi-align-justify' }
    ];
    selectedShowType: string = 'chart';

    positions?: TreeNode<PositionModel>[];

    ref: DynamicDialogRef | undefined;

    constructor(private positionService: PositionService,
        public dialogService: DialogService,
    ) {

    }

    ngOnInit() {
        this.fetchData();
    }

    fetchData() {
        this.isLoading = true;
        this.positionService.getAllTree()
            .pipe(finalize(() => {
                this.isLoading = false;
            }))
            .subscribe(response => {
                this.positions = response;
            });
    }

    openAdd(parentItem: PositionModel) {
        const config: PageDialogConfig = {
            extraData: parentItem,
            component: CreatePositionPageComponent,
            header: 'Add New Department',
            description: 'this is a desciption of the add person page',
            isFullScreen: false,
        };
        this.ref = openDialog(config, this.dialogService);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.fetchData();
                // this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: product.name });
            }
        });
    }

    openEdit(item: PositionModel) {
        const config: PageDialogConfig = {
            extraData: item,
            component: EditPositionPageComponent,
            header: 'Edit Department',
            description: 'this is a desciption of the Edit Department',
            isFullScreen: false,
        };
        this.ref = openDialog(config, this.dialogService);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.fetchData();
                // this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: product.name });
            }
        });
    }

    deleteItem(item: PositionModel) {
        //TODO: translate
        this.ref = openConfirmDeleteDialog(`Are you sure you want to delete ${item.title}?`, this.dialogService);

        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.isLoading = true;
                this.positionService.delete(item.id)
                    .pipe(finalize(() => {
                        this.isLoading = false;
                    }))
                    .subscribe(response => {
                        this.fetchData();
                    });
            }
        });
    }

}
