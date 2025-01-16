import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Customer } from '../../user/user-list/user-list-page.component';
import { BooleanColumnDisplayEnum, TableBooleanColumn, TableColumnBase, TableTextColumn } from '../../../../../core/components/png-table/models/table-column-model';
import { CreateRoleCommand } from '../../../models/commands/create-role-command';
import { MessageService, TreeNode } from 'primeng/api';
import { FormBuilder } from '@angular/forms';
import { BasicModule } from '../../../../../core/basic.module';
import { PngTableComponent } from '../../../../../core/components/png-table/png-table.component';
import { DepartmentModel } from '../../../models/queries/department-model';
import { DepartmentService } from '../../../apis/department.service';
import { finalize, forkJoin, Observable, of } from 'rxjs';
import { Tree } from 'primeng/tree';
import { RoleService } from '../../../apis/role.service';
import { PermissiontModel } from '../../../models/queries/permission-model';


@Component({
    selector: 'app-create-role-page',
    standalone: true,
    imports: [BasicModule,
        PngTableComponent,
        Tree],
    providers: [MessageService],
    templateUrl: './create-role-page.component.html',
    styleUrl: './create-role-page.component.scss'
})
export class CreateRolePageComponent {
    isLoading = false;

    roles!: Customer[];//todo: cheange table data
    departments?: TreeNode<DepartmentModel>[];
    permissions?: TreeNode<PermissiontModel>[];
    selectedPermissions!: TreeNode[];

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

    @Input()
    showValidationWarning = true;

    @Output()
    commandChange = new EventEmitter<CreateRoleCommand | null>();

    form = this.fb.group({
        title: this.fb.control<string | null>(null),
        uniqueName: this.fb.control<string | null>(null),
        description: this.fb.control<string | null>(null),
        department: this.fb.control<TreeNode | null>(null),
        permissionIds: this.fb.control<[number] | null>(null),
    })


    constructor(private messageService: MessageService,
        private departmentService: DepartmentService,
        private roleService: RoleService,
        public fb: FormBuilder) {

    }

    ngOnInit() {
        this.isLoading = true;

        forkJoin([
            this.departmentService.getAllTree(),
            this.roleService.getAllTree()
        ]).pipe(finalize(() => {
            this.isLoading = false;
        })).subscribe(response => {
            this.departments = response[0];
            this.permissions = response[1];
        });
    }


    save(): Observable<boolean> {
        if (this.form.valid) {
            const { department, ...formValues } = this.form.getRawValue();
            const command = <CreateRoleCommand>{
                ...formValues,
                uniqueName: "todo",
                departmentId: this.form.controls.department.value?.data.id,
                permissionIds: this.selectedPermissions.map(x => x.data.id),
            }

            return new Observable((subscriber) => {
                this.roleService.create(command).subscribe(data => {

                    subscriber.next(true);
                });
            });

        }
        else
            return of(false);
    }

}
