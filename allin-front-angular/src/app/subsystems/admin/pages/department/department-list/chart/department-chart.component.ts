import { Component, Input } from '@angular/core';
import { TreeNode } from 'primeng/api';
import { OrganizationChartModule } from 'primeng/organizationchart';
import { DepartmentModel } from '../../../../models/queries/department-model';
import { BasicModule } from '../../../../../../core/basic.module';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { CreateDepartmentPageComponent } from '../../create-department/create-department-page.component';
import { openDialog, PageDialogConfig } from '../../../../../../core/components/page-dialog/page-dialog.component';
@Component({
  selector: 'app-department-chart',
  standalone: true,
  imports: [BasicModule,
    OrganizationChartModule
  ],
  templateUrl: './department-chart.component.html',
  styleUrl: './department-chart.component.scss'
})
export class DepartmentChartComponent {

  @Input()
  data?: TreeNode<DepartmentModel>[];

  ref: DynamicDialogRef | undefined;

  constructor(public dialogService: DialogService,) { }
  openAdd(item: DepartmentModel) {
    const config: PageDialogConfig = {
      component: CreateDepartmentPageComponent,
      header: 'Add New Department',
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
