import { Component } from '@angular/core';
import { PngTableComponent } from '../../../../../core/components/png-table/png-table.component';
import { BasicModule } from '../../../../../core/basic.module';
import { BooleanColumnDisplayEnum, TableBooleanColumn, TableColumnBase, TableTextColumn } from '../../../../../core/components/png-table/models/table-column-model';
import { Table } from 'primeng/table';
import { UserService } from '../../../apis/user.service';
import { TagModule } from 'primeng/tag';
import { ToolbarModule } from 'primeng/toolbar';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { CreateUserPageComponent } from '../create-user/create-user-page.component';
import { openDialog, PageDialogComponent, PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { TranslateService } from '@ngx-translate/core';
import { Message } from 'primeng/message';

@Component({
    selector: 'app-user-list-page',
    standalone: true,
    imports: [
        BasicModule,
        PngTableComponent,
        ToolbarModule,
        TagModule],
    providers: [DialogService],
    templateUrl: './user-list-page.component.html',
    styleUrl: './user-list-page.component.scss'
})
export class UserListPageComponent {

    columns: TableColumnBase[] = [
        new TableTextColumn({
            title: 'Name',
            rootFieldName: 'name',
            sortable: false,
        }),
        new TableTextColumn({
            title: 'Country',
            rootFieldName: 'country',
            templateRefId: 'countryColumnTemplate',
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

        // this.translate.get('admin.user.msg1').subscribe((res: string) => {
        //     console.log(res);
        //     this.messages = [{ severity: 'info', detail: res }];
        // });
    }



    ngOnInit() {
        this.cities = [
            { name: 'New York', code: 'NY' },
            { name: 'Rome', code: 'RM' },
            { name: 'London', code: 'LDN' },
            { name: 'Istanbul', code: 'IST' },
            { name: 'Paris', code: 'PRS' }
        ];
        this.userService.getCustomersLarge().then((customers) => {
            this.customers = customers;
            this.loading = false;

            this.customers.forEach((customer) => (customer.date = new Date(<Date>customer.date)));
        });

        this.representatives = [
            { name: 'Amy Elsner', image: 'amyelsner.png' },
            { name: 'Anna Fali', image: 'annafali.png' },
            { name: 'Asiya Javayant', image: 'asiyajavayant.png' },
            { name: 'Bernardo Dominic', image: 'bernardodominic.png' },
            { name: 'Elwin Sharvill', image: 'elwinsharvill.png' },
            { name: 'Ioni Bowcher', image: 'ionibowcher.png' },
            { name: 'Ivan Magalhaes', image: 'ivanmagalhaes.png' },
            { name: 'Onyama Limba', image: 'onyamalimba.png' },
            { name: 'Stephen Shaw', image: 'stephenshaw.png' },
            { name: 'Xuxue Feng', image: 'xuxuefeng.png' }
        ];

        this.statuses = [
            { label: 'Unqualified', value: 'unqualified' },
            { label: 'Qualified', value: 'qualified' },
            { label: 'New', value: 'new' },
            { label: 'Negotiation', value: 'negotiation' },
            { label: 'Renewal', value: 'renewal' },
            { label: 'Proposal', value: 'proposal' }
        ];
    }


    getSeverity(status: string) {
        switch (status) {
            case 'unqualified':
                return 'danger';

            case 'qualified':
                return 'success';

            case 'new':
                return 'info';

            case 'negotiation':
                return 'warn';

            default:
                return 'info';
        }
    }

    openAddUser() {

        this.ref = openDialog(this.dialogService, CreateUserPageComponent);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                // this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: product.name });
            }
        });
    }
}

export interface Country {
    name?: string;
    code?: string;
}

export interface Representative {
    name?: string;
    image?: string;
}

export interface Customer {
    id?: number;
    name?: string;
    country?: Country;
    company?: string;
    date?: string | Date;
    status?: string;
    activity?: number;
    representative?: Representative;
    verified?: boolean;
    balance?: number;
}
