import { Component } from '@angular/core';
import { ToolbarModule } from 'primeng/toolbar';
import { BasicModule } from '../../../../../core/basic.module';
import { PngTableComponent } from '../../../../../core/components/png-table/png-table.component';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { BooleanColumnDisplayEnum, TableBooleanColumn, TableColumnBase, TableTextColumn } from '../../../../../core/components/png-table/models/table-column-model';
import { Representative } from '../../user/user-list/user-list-page.component';
import { Message } from 'primeng/message';
import { UserService } from '../../../apis/user.service';
import { TranslateService } from '@ngx-translate/core';
import { openDialog, PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { AddPersonPageComponent } from '../add-person/add-person-page.component';
import { PersonService } from '../../../apis/person.service';
import { PersonModel } from '../../../models/queries/person-model';
import { NoToolbarCTableConfig } from '../../../../../core/components/png-table/models/table-config-options';
import { environment } from '../../../../../../environments/environment';

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
    noToolbarCTableConfig = NoToolbarCTableConfig;

    columns: TableColumnBase[] = [
        new TableTextColumn({
            title: 'First Name',
            rootFieldName: 'firstName',
        }),
        new TableTextColumn({
            title: 'Last Name',
            rootFieldName: 'lastName',
        }),
        new TableTextColumn({
            title: 'SSN',
            rootFieldName: 'ssn',
        }),
        new TableTextColumn({
            title: 'Email',
            rootFieldName: 'email',
        }),
        // new TableTextColumn({
        //     title: 'Status',
        //     rootFieldName: 'email',
        //     templateRefId: 'statusColumnTemplate',
        //     sortable: false,
        // }),
        // new TableBooleanColumn({
        //     title: 'Verified',
        //     rootFieldName: 'verified',
        //     sortable: false,
        //     displayStyle: BooleanColumnDisplayEnum.OnlyCheckColorFull
        // })
    ];

    ref: DynamicDialogRef | undefined;

    persons!: PersonModel[];
    representatives!: Representative[];
    statuses!: any[];
    loading: boolean = true;
    cities: any[] | undefined;
    selectedCity: any | undefined;
    messages: Message[] = [];
    dataApiUrl = {
        controller: `person`,
        action: 'get-all',
        routeParameters: []
    };

    constructor(private userService: UserService,
        public dialogService: DialogService,
        private translate: TranslateService,
        private personService: PersonService
    ) {

    }

    ngOnInit() {

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
