import { Component } from '@angular/core';
import { ToolbarModule } from 'primeng/toolbar';
import { BasicModule } from '../../../../../core/basic.module';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { Representative } from '../../user/user-list/user-list-page.component';
import { Message } from 'primeng/message';
import { TranslateService } from '@ngx-translate/core';
import { openDialog, PageDialogConfig } from '../../../../../core/components/page-dialog/page-dialog.component';
import { CreateDepartmentPageComponent } from '../create-department/create-department-page.component';
import { DepartmentChartComponent } from './chart/department-chart.component';
import { SelectButton } from 'primeng/selectbutton';
import { DepartmentGridComponent } from './grid/department-grid.component';
import { DepartmentService } from '../../../apis/department.service';
import { DepartmentModel } from '../../../models/queries/department-model';
import { TreeNode } from 'primeng/api';
import { EditDepartmentPageComponent } from '../edit-department/edit-department-page.component';
import { finalize } from 'rxjs';
import { ConfirmDialogConfig, openConfirmDeleteDialog, openConfirmDialog } from '../../../../../core/components/confirm-dialog/confirm-dialog.component';

@Component({
    selector: 'app-department-list-page',
    standalone: true,
    imports: [
        BasicModule,
        ToolbarModule,
        DepartmentChartComponent,
        DepartmentGridComponent,
        SelectButton
    ],
    providers: [DialogService],
    templateUrl: './department-list-page.component.html',
    styleUrl: './department-list-page.component.scss'
})
export class DepartmentListPageComponent {

    isLoading = false;

    stateOptions: any[] = [
        { label: 'Chart', value: 'chart', icon: 'pi pi-sitemap' },
        { label: 'Grid', value: 'grid', icon: 'pi pi-align-justify' }
    ];
    selectedShowType: string = 'chart';

    ref: DynamicDialogRef | undefined;

    departments?: TreeNode<DepartmentModel>[];
    representatives!: Representative[];
    statuses!: any[];
    loading: boolean = true;
    cities: any[] | undefined;
    selectedCity: any | undefined;
    messages: Message[] = [];

    constructor(private departmentService: DepartmentService,
        public dialogService: DialogService,
        private translate: TranslateService
    ) {

    }

    ngOnInit() {
        this.fetchData();
    }

    fetchData() {
        this.isLoading = true;
        this.departmentService.getAllTree()
            .pipe(finalize(() => {
                this.isLoading = false;
            }))
            .subscribe(response => {
                this.departments = response;
            });
    }

    openAdd(parentItem: DepartmentModel) {
        const config: PageDialogConfig = {
            extraData: parentItem,
            component: CreateDepartmentPageComponent,
            header: 'Add New Department',
            description: 'this is a desciption of the add person page',
            isFullScreen: false,
        };
        this.ref = openDialog(config, this.dialogService);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.fetchData();
                // this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: product.name });
            }
        });
    }

    openEdit(item: DepartmentModel) {
        const config: PageDialogConfig = {
            extraData: item,
            component: EditDepartmentPageComponent,
            header: 'Edit Department',
            description: 'this is a desciption of the Edit Department',
            isFullScreen: false,
        };
        this.ref = openDialog(config, this.dialogService);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.fetchData();
                // this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: product.name });
            }
        });
    }

    deleteItem(item: DepartmentModel) {
        //TODO: translate
        this.ref = openConfirmDeleteDialog(`Are you sure you want to delete ${item.title}?`, this.dialogService);

        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                this.isLoading = true;
                this.departmentService.delete(item.id)
                    .pipe(finalize(() => {
                        this.isLoading = false;
                    }))
                    .subscribe(response => {
                        this.fetchData();
                    });
            }
        });
    }

}
