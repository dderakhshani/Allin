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

        this.departmentService.getAllTree()
            .subscribe(response => {
                this.departments = response;
            });
    }

    openAdd() {
        const config: PageDialogConfig = {
            component: CreateDepartmentPageComponent,
            header: 'Add New department',
            description: 'this is a desciption of the add department page',
        };
        this.ref = openDialog(config, this.dialogService);
        this.ref.onClose.subscribe((result: any) => {
            if (result) {
                // this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: product.name });
            }
        });
    }
}
