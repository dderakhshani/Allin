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
import { CreateRolePageComponent } from '../create-role/create-role-page.component';
import { TreeNode } from 'primeng/api';
import { TableModule } from 'primeng/table';
import { RoleService } from '../../../apis/role.service';
import { finalize } from 'rxjs';
import { RoleModel } from '../../../models/queries/role-model';

@Component({
    selector: 'app-role-list-page',
    standalone: true,
    imports: [
        BasicModule,
        PngTableComponent,
        ToolbarModule,
        TableModule
    ],
    providers: [DialogService],
    templateUrl: './role-list-page.component.html',
    styleUrl: './role-list-page.component.scss'
})
export class RoleListPageComponent {
    isLoading = false;

    roles!: RoleModel[];
    products!: RoleModel[];

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
        private translate: TranslateService,
        private roleService: RoleService,
    ) {

    }

    ngOnInit() {
        this.fetchRoleListData();
    }

    fetchRoleListData() {
        this.isLoading = true;
        this.roleService.getAll()
            .pipe(finalize(() => {
                this.isLoading = false;
            }))
            .subscribe(response => {
                this.roles = response;
                this.products = response;
            });
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
                // this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: product.name });
            }
        });
    }
}
