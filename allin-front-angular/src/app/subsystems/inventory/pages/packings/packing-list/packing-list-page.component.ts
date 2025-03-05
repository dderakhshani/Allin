import { Component, signal } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { PngTableComponent } from '../../../../../core/components/png-table/png-table.component';
import { ToolbarModule } from 'primeng/toolbar';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TableColumnBase, TableTextColumn } from '../../../../../core/components/png-table/models/table-column-model';
import { openDialog, PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { CreatePackingPageComponent } from '../create-packing/create-packing-page.component';
import { PackingModel } from '../../../models/queries/packing-model';

@Component({
    selector: 'app-packing-list-page',
    standalone: true,
    imports: [BasicModule,
        PngTableComponent,
        ToolbarModule],
    providers: [DialogService],
    templateUrl: './packing-list-page.component.html',
    styleUrl: './packing-list-page.component.scss'
})
export class PackingListPageComponent {

    isLoading = true;

    constructor(public dialogService: DialogService,
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
            title: 'LevelCode',
            rootFieldName: 'levelCode',
            sortable: false,
        }),
        new TableTextColumn({
            title: 'Title',
            rootFieldName: 'title',
            sortable: false,
        }),
        new TableTextColumn({
            title: 'Conversion Factor',
            rootFieldName: 'conversionFactor',
            sortable: false,
        }),
        new TableTextColumn({
            title: 'Measure Unit',
            rootFieldName: 'measureUnitBaseId',
            sortable: false,
        })
    ];

    ref: DynamicDialogRef | undefined;

    loading: boolean = true;
    fetchDataTrigger = signal<boolean>(true)

    packingApiUrl = {
        controller: `inventory/Packing`,
        action: 'get-all',
        routeParameters: []
    };

    openAdd() {
        const config: PageDialogConfig = {
            component: CreatePackingPageComponent,
            header: 'Add New Packing',
            description: 'this is a desciption of the add Packing page',
        };
        this.ref = openDialog(config, this.dialogService);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.fetchDataTrigger.update((value) => !value);
            }
        });
    }

    loadInnerData(item: PackingModel) {
        // this.isLoading = true;
        // this.basevalueService.getItemsTreeByBaseValueId(item.id)
        //     .pipe(finalize(() => {
        //         this.isLoading = false;
        //     }))
        //     .subscribe(response => {
        //         item.items = response;
        //     });
    }
    editClick(item: PackingModel) {
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
    deleteClick(item: PackingModel) {
        //TODO: translate
        // this.ref = openConfirmDeleteDialog(`Are you sure you want to delete ${item.title}?`, this.dialogService);

        // this.ref.onClose.subscribe((result: any) => {
        //     if (result) {
        //         this.isLoading = true;
        //         this.basevalueService.delete(item.id)
        //             .pipe(finalize(() => {
        //                 this.isLoading = false;
        //             }))
        //             .subscribe(response => {
        //                 //TODO: reloade grid data
        //             });
        //     }
        // });
    }

}
