import { Component, Input } from '@angular/core';
import { RoleModel } from '../../../models/queries/role-model';
import { IFormDialogContainer, PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { BasicModule } from '../../../../../core/basic.module';
import { MessageService, TreeNode } from 'primeng/api';
import { DepartmentService } from '../../../apis/department.service';
import { RoleService } from '../../../apis/role.service';
import { FormBuilder } from '@angular/forms';
import { finalize, forkJoin, Observable, of } from 'rxjs';
import { DepartmentModel } from '../../../models/queries/department-model';
import { PermissiontModel } from '../../../models/queries/permission-model';
import { EditRoleCommand } from '../../../models/commands/edit-role-command';
import { Tree } from 'primeng/tree';
import { DynamicDialogConfig } from 'primeng/dynamicdialog';

@Component({
    selector: 'app-edit-role-page',
    standalone: true,
    imports: [BasicModule,
        Tree
    ],
    providers: [MessageService],
    templateUrl: './edit-role-page.component.html',
    styleUrl: './edit-role-page.component.scss'
})
export class EditRolePageComponent implements IFormDialogContainer {
    isLoading = false;
    @Input()
    item?: RoleModel;

    departments?: TreeNode<DepartmentModel>[];
    permissions?: TreeNode<PermissiontModel>[];
    selectedPermissions!: TreeNode[];

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
        public dialogConfig: DynamicDialogConfig<PageDialogConfig>,
        public fb: FormBuilder) {
        this.item = dialogConfig.data?.extraData;
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

        this.form.patchValue({
            title: this.item?.title,
            uniqueName: this.item?.uniqueName,
            description: this.item?.description,
        });

    }

    save(): Observable<boolean> {
        if (this.form.valid) {
            const { department, ...formValues } = this.form.getRawValue();
            const command = <EditRoleCommand>{
                ...formValues,
                departmentId: this.form.controls.department.value?.data.id,
                permissionIds: this.selectedPermissions.map(x => x.data.id),
            }

            return new Observable((subscriber) => {
                this.roleService.edit(command).subscribe(data => {

                    subscriber.next(true);
                });
            });

        }
        else
            return of(false);
    }
}
