import { Component, signal } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { PngTableComponent } from '../../../../../core/components/png-table/png-table.component';
import { ToolbarModule } from 'primeng/toolbar';
import { TreeTableModule } from 'primeng/treetable';
import { TableColumnBase, TableTextColumn } from '../../../../../core/components/png-table/models/table-column-model';
import { BaseValueTypeModel } from '../../../models/queries/base-value-type-model';
import { openDialog, PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { CreateBasevaluePageComponent } from '../create-basevalue/create-basevalue-page.component';
import { BasevalueService } from '../../../apis/basevalue.service';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { finalize } from 'rxjs';
import { BaseValueItemModel } from '../../../models/queries/base-value-item-model';
import { TreeNode } from 'primeng/api';
import { openConfirmDeleteDialog } from '../../../../../core/components/confirm-dialog/confirm-dialog.component';

@Component({
    selector: 'app-basevalue-list-page',
    standalone: true,
    imports: [BasicModule,
        PngTableComponent,
        ToolbarModule,
        TreeTableModule],
    providers: [DialogService],
    templateUrl: './basevalue-list-page.component.html',
    styleUrl: './basevalue-list-page.component.scss'
})
export class BasevalueListPageComponent {

    isLoading = true;

    constructor(private basevalueService: BasevalueService,
        public dialogService: DialogService,
    ) {

    }

    columns: TableColumnBase[] = [
        new TableTextColumn({
            title: '',
            rootFieldName: '',
            templateRefId: 'actionColumnTemplate',
            sortable: false,
        }),
        new TableTextColumn({
            title: 'title',
            rootFieldName: 'title',
            sortable: false,
        }),
        new TableTextColumn({
            title: 'uniqueName',
            rootFieldName: 'uniqueName',
            sortable: false,
        }),
        new TableTextColumn({
            title: 'description',
            rootFieldName: 'description',
            sortable: false,
        })
    ];

    baseValueTypes!: BaseValueTypeModel[];
    ref: DynamicDialogRef | undefined;

    loading: boolean = true;
    fetchDataTrigger = signal<boolean>(true)

    items?: TreeNode<BaseValueItemModel>[];

    baseValueTypeApiUrl = {
        controller: `base-value`,
        action: 'get-all-type-values',
        routeParameters: []
    };


    openAdd() {
        const config: PageDialogConfig = {
            component: CreateBasevaluePageComponent,
            header: 'Add New base value',
            description: 'this is a desciption of the add base value page',
        };
        this.ref = openDialog(config, this.dialogService);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.fetchDataTrigger.update((value) => !value);
            }
        });
    }

    loadInnerData(item: BaseValueTypeModel) {
        this.isLoading = true;
        this.basevalueService.getItemsTreeByBaseValueId(item.id)
            .pipe(finalize(() => {
                this.isLoading = false;
            }))
            .subscribe(response => {
                item.items = response;
            });
    }
    editClick(item: BaseValueTypeModel) {
        // const config: PageDialogConfig = {
        //     extraData: item,
        //     component: EditRolePageComponent,
        //     header: 'Edit Role',
        //     description: 'this is a desciption of the Edit Role',
        //     isFullScreen: false,
        // };
        // this.ref = openDialog(config, this.dialogService);
        // this.ref.onClose.subscribe((result: any) => {
        //     if (result) {
        //         // this.fetchData(); //TODO: reloade grid data
        //         // this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: product.name });
        //     }
        // });
    }
    deleteClick(item: BaseValueTypeModel) {
        //TODO: translate
        this.ref = openConfirmDeleteDialog(`Are you sure you want to delete ${item.title}?`, this.dialogService);

        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.isLoading = true;
                this.basevalueService.delete(item.id)
                    .pipe(finalize(() => {
                        this.isLoading = false;
                    }))
                    .subscribe(response => {
                        //TODO: reloade grid data
                    });
            }
        });
    }
    deleteItemClick(item: BaseValueItemModel) {
        //TODO: translate
        this.ref = openConfirmDeleteDialog(`Are you sure you want to delete ${item.title}?`, this.dialogService);

        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.isLoading = true;
                this.basevalueService.deleteItems(item.id)
                    .pipe(finalize(() => {
                        this.isLoading = false;
                    }))
                    .subscribe(response => {
                        //TODO: reloade grid data
                    });
            }
        });
    }
}
