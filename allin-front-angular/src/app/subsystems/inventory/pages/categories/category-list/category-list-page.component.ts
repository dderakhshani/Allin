import { Component, signal } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { PngTableComponent } from '../../../../../core/components/png-table/png-table.component';
import { ToolbarModule } from 'primeng/toolbar';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { openDialog, PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { CreateCategoryPageComponent } from '../create-category/create-category-page.component';
import { TableColumnBase, TableTextColumn } from '../../../../../core/components/png-table/models/table-column-model';
import { CategoryModel } from '../../../models/queries/category-model';

@Component({
    selector: 'app-category-list-page',
    standalone: true,
    imports: [BasicModule,
        PngTableComponent,
        ToolbarModule
    ],
    providers: [DialogService],
    templateUrl: './category-list-page.component.html',
    styleUrl: './category-list-page.component.scss'
})
export class CategoryListPageComponent {
    isLoading = true;

    constructor(
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
            title: 'code',
            rootFieldName: 'code',
            sortable: false,
        }),
        new TableTextColumn({
            title: 'description',
            rootFieldName: 'description',
            sortable: false,
        })
    ];

    ref: DynamicDialogRef | undefined;
    loading: boolean = true;
    fetchDataTrigger = signal<boolean>(true)

    categoryApiUrl = {
        controller: `inventory-category`,
        action: 'get-all',
        routeParameters: []
    };

    openAdd() {
        const config: PageDialogConfig = {
            component: CreateCategoryPageComponent,
            header: 'Add New Category',
            description: 'this is a desciption of the add Category page',
        };
        this.ref = openDialog(config, this.dialogService);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.fetchDataTrigger.update((value) => !value);
            }
        });
    }

    loadInnerData(item: CategoryModel) {
        //     this.isLoading = true;
        //     this.basevalueService.getItemsTreeByBaseValueId(item.id)
        //         .pipe(finalize(() => {
        //             this.isLoading = false;
        //         }))
        //         .subscribe(response => {
        //             item.items = response;
        //         });
    }

    editClick(item: CategoryModel) {
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
    deleteClick(item: CategoryModel) {
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
