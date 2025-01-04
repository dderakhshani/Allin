import { Component } from '@angular/core';
import { CreateEmployeePageComponent } from '../create-employee/create-employee-page.component';
import { TranslateService } from '@ngx-translate/core';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { Message } from 'primeng/message';
import { PageDialogConfig, openDialog } from '../../../../../core/components/page-dialog/page-dialog.component';
import { TableColumnBase, TableTextColumn, TableBooleanColumn, BooleanColumnDisplayEnum } from '../../../../../core/components/png-table/models/table-column-model';
import { UserService } from '../../../apis/user.service';
import { Customer, Representative } from '../../user/user-list/user-list-page.component';
import { ToolbarModule } from 'primeng/toolbar';
import { BasicModule } from '../../../../../core/basic.module';
import { PngTableComponent } from '../../../../../core/components/png-table/png-table.component';

@Component({
    selector: 'app-employee-list-page',
    standalone: true,
    imports: [
        BasicModule,
        PngTableComponent,
        ToolbarModule,

    ],
    providers: [DialogService],
    templateUrl: './employee-list-page.component.html',
    styleUrl: './employee-list-page.component.scss'
})
export class EmployeeListPageComponent {

    isLoading = false;

    columns: TableColumnBase[] = [
        new TableTextColumn({
            title: 'Name',
            rootFieldName: 'name',
            sortable: false,
        }),
        new TableTextColumn({
            title: 'Last Name',
            rootFieldName: 'country',
            sortable: false,
        }),
        new TableTextColumn({
            title: 'Agent',
            rootFieldName: 'agent',
            sortable: false,
        }),
        new TableTextColumn({
            title: 'Status',
            rootFieldName: 'status',
            templateRefId: 'statusColumnTemplate',
            sortable: false,
        }),
        new TableBooleanColumn({
            title: 'Verified',
            rootFieldName: 'verified',
            sortable: false,
            displayStyle: BooleanColumnDisplayEnum.OnlyCheckColorFull
        })
    ];

    ref: DynamicDialogRef | undefined;

    customers!: Customer[];
    representatives!: Representative[];
    statuses!: any[];
    loading: boolean = true;
    cities: any[] | undefined;
    selectedCity: any | undefined;
    messages: Message[] = [];

    constructor(private userService: UserService,
        public dialogService: DialogService,
        private translate: TranslateService
    ) {

    }

    openAdd() {
        const config: PageDialogConfig = {
            component: CreateEmployeePageComponent,
            header: 'Add New Employee',
            description: 'this is a desciption of the add employee page',
        };
        this.ref = openDialog(config, this.dialogService);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                // this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: product.name });
            }
        });
    }
}
