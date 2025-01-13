import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TreeNode } from 'primeng/api';
import { OrganizationChartModule } from 'primeng/organizationchart';
import { DepartmentModel } from '../../../../models/queries/department-model';
import { BasicModule } from '../../../../../../core/basic.module';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { DepartmentService } from '../../../../apis/department.service';
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
  @Output()
  onEditClick = new EventEmitter<DepartmentModel>();
  @Output()
  onDeleteClick = new EventEmitter<DepartmentModel>();

  ref: DynamicDialogRef | undefined;

  constructor(public dialogService: DialogService,
    private departmentService: DepartmentService,
  ) { }

  addChildClick(node: TreeNode<DepartmentModel>) {
    this.onAddChildClick.emit(node.data);
  }

  deleteClick(node: TreeNode<DepartmentModel>) {

    if (node.data) {
      let item: DepartmentModel = { ...node.data };
      this.onDeleteClick.emit(item);
    }
  }
}