import { Component, signal } from '@angular/core';
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
import { CreateRolePageComponent } from '../create-role/create-role-page.component';
import { TreeNode } from 'primeng/api';
import { TableModule } from 'primeng/table';
import { RoleService } from '../../../apis/role.service';
import { finalize } from 'rxjs';
import { RoleModel } from '../../../models/queries/role-model';
import { PermissiontModel } from '../../../models/queries/permission-model';
import { TreeTableModule } from 'primeng/treetable';
import { openConfirmDeleteDialog } from '../../../../../core/components/confirm-dialog/confirm-dialog.component';

@Component({
    selector: 'app-role-list-page',
    standalone: true,
    imports: [
        BasicModule,
        PngTableComponent,
        ToolbarModule,
        TreeTableModule
    ],
    providers: [DialogService],
    templateUrl: './role-list-page.component.html',
    styleUrl: './role-list-page.component.scss'
})
export class RoleListPageComponent {
    isLoading = true;

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

    roles!: RoleModel[];

    ref: DynamicDialogRef | undefined;

    representatives!: Representative[];
    statuses!: any[];
    loading: boolean = true;
    cities: any[] | undefined;
    selectedCity: any | undefined;
    messages: Message[] = [];
    fetchDataTrigger = signal<boolean>(true)

    roleApiUrl = {
        controller: `role-permission`,
        action: 'get-all',
        routeParameters: []
    };

    constructor(private userService: UserService,
        public dialogService: DialogService,
        private translate: TranslateService,
        private roleService: RoleService,
    ) {

    }

    ngOnInit() {
    }



    openAdd() {
        const config: PageDialogConfig = {
            component: CreateRolePageComponent,
            header: 'Add New Role',
            description: 'this is a desciption of the add role page',
        };
        this.ref = openDialog(config, this.dialogService);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.fetchDataTrigger.update((value) => !value);
            }
        });
    }

    loadInnerData(item: RoleModel) {
        this.isLoading = true;
        this.roleService.getPermissionsTreeByRoleId(item.id)
            .pipe(finalize(() => {
                this.isLoading = false;
            }))
            .subscribe(response => {
                item.permissions = response;
            });
    }

    // editClick(item: RoleModel) {
    //     this.onEditClick.emit(item);
    // }

    deleteClick(item: RoleModel) {
        //TODO: translate
        this.ref = openConfirmDeleteDialog(`Are you sure you want to delete ${item.title}?`, this.dialogService);

        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.isLoading = true;
                this.roleService.delete(item.id)
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
