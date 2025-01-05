import { Component } from '@angular/core';
import { ToolbarModule } from 'primeng/toolbar';
import { BasicModule } from '../../../../../core/basic.module';
import { PngTableComponent } from '../../../../../core/components/png-table/png-table.component';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { BooleanColumnDisplayEnum, TableBooleanColumn, TableColumnBase, TableTextColumn } from '../../../../../core/components/png-table/models/table-column-model';
import { Customer, Representative } from '../../user/user-list/user-list-page.component';
import { Message } from 'primeng/message';
import { UserService } from '../../../apis/user.service';
import { TranslateService } from '@ngx-translate/core';
import { openDialog, PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { AddPersonPageComponent } from '../add-person/add-person-page.component';

@Component({
  selector: 'app-person-list-page',
  standalone: true,
  imports: [
            BasicModule,
            PngTableComponent,
            ToolbarModule,
  ],
  providers: [DialogService],
  templateUrl: './person-list-page.component.html',
  styleUrl: './person-list-page.component.scss'
})
export class PersonListPageComponent {
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
            component: AddPersonPageComponent,
            header: 'Add New Person',
            description: 'this is a desciption of the add person page',
        };
        this.ref = openDialog(config, this.dialogService);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                // this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: product.name });
            }
        });
    }
}
