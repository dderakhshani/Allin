import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TreeNode } from 'primeng/api';
import { TreeTableModule } from 'primeng/treetable';
import { DepartmentModel } from '../../../../models/queries/department-model';
import { BasicModule } from '../../../../../../core/basic.module';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { DepartmentService } from '../../../../apis/department.service';

@Component({
  selector: 'app-position-grid',
  standalone: true,
  imports: [
    BasicModule,
    TreeTableModule],
  templateUrl: './position-grid.component.html',
  styleUrl: './position-grid.component.scss'
})
export class PositionGridComponent {

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

  ngOnInit() {
  }

  addChildClick(item: DepartmentModel) {
    this.onAddChildClick.emit(item);
  }

  editClick(item: DepartmentModel) {
    this.onEditClick.emit(item);
  }

  deleteClick(item: DepartmentModel) {
    this.onDeleteClick.emit(item);
  }

}
