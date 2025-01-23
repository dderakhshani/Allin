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

    fetchDataTrigger = signal<boolean>(true)
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
        // this.roleService.getPermissionsTreeByRoleId(item.id)
        //     .pipe(finalize(() => {
        //         this.isLoading = false;
        //     }))
        //     .subscribe(response => {
        //         item.permissions = response;
        //     });
    }

}
