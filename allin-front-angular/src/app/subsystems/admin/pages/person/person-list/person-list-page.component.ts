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
import { openConfirmDeleteDialog } from '../../../../../core/components/confirm-dialog/confirm-dialog.component';
import { finalize } from 'rxjs';

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
            title: '',
            rootFieldName: '',
            templateRefId: 'actionColumnTemplate',
            sortable: false,
        }),
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
        controller: `admin/person`,
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

    editClick(item: PersonModel) {
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

    deleteClick(item: PersonModel) {
        //TODO: translate
        this.ref = openConfirmDeleteDialog(`Are you sure you want to delete ${item.firstName} ${item.lastName}?`, this.dialogService);

        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.isLoading = true;
                this.personService.delete(item.id)
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
