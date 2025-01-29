import { Component } from '@angular/core';
import { BasicModule } from '../../../../../core/basic.module';
import { PngTableComponent } from '../../../../../core/components/png-table/png-table.component';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TableColumnBase, TableTextColumn } from '../../../../../core/components/png-table/models/table-column-model';
import { openDialog, PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { CreateExtendedFieldPageComponent } from '../create-extended-field/create-extended-field-page.component';
import { ExtendedFieldsService } from '../../../../shared/apis/extended-fields.service';
import { ExtendedFieldTableNamesEnum } from '../../../../shared/models/enums/extended-field-table-enum';

@Component({
    selector: 'app-extended-field-list-page',
    standalone: true,
    imports: [BasicModule,
        PngTableComponent,
    ],
    providers: [DialogService],
    templateUrl: './extended-field-list-page.component.html',
    styleUrl: './extended-field-list-page.component.scss'
})
export class ExtendedFieldListPageComponent {
    isLoading = false;

    columns: TableColumnBase[] = [
        new TableTextColumn({
            title: 'Table Name',
            rootFieldName: 'name',
            sortable: false,
        })
    ];

    tableNames: { name: string }[] = [];


    ref: DynamicDialogRef | undefined;

    constructor(private extendedFieldsService: ExtendedFieldsService,
        public dialogService: DialogService,
    ) {

    }
    ngOnInit() {
        this.tableNames = Object.values(ExtendedFieldTableNamesEnum).map(name => ({ name }));
    }


    openAdd() {
        const config: PageDialogConfig = {
            component: CreateExtendedFieldPageComponent,
            header: 'Add New Place',
            description: 'this is a desciption of the add Place page',
            isFullScreen: false,
        };
        this.ref = openDialog(config, this.dialogService);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                // this.fetchData();
                // this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: product.name });
            }
        });
    }

    loadInnerData(data: any) {

    }
}
