import { Component, EventEmitter, Input, Output } from '@angular/core';
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
  @Output()
  onAddChildClick = new EventEmitter<DepartmentModel>();

  ref: DynamicDialogRef | undefined;

  constructor(public dialogService: DialogService,) { }
  openAdd(item: DepartmentModel) {
    this.onAddChildClick.emit(item);
  }
}
