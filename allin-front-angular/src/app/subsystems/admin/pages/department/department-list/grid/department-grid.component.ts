import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TreeNode } from 'primeng/api';
import { TreeTableModule } from 'primeng/treetable';
import { DepartmentModel } from '../../../../models/queries/department-model';
import { BasicModule } from '../../../../../../core/basic.module';
import { openDialog, PageDialogConfig } from '../../../../../../core/components/page-dialog/page-dialog.component';
import { CreateDepartmentPageComponent } from '../../create-department/create-department-page.component';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-department-grid',
  standalone: true,
  imports: [
    BasicModule,
    TreeTableModule],
  templateUrl: './department-grid.component.html',
  styleUrl: './department-grid.component.scss'
})
export class DepartmentGridComponent {

  @Input()
  data?: TreeNode<DepartmentModel>[];

  @Output()
  onAddChildClick = new EventEmitter<DepartmentModel>();

  ref: DynamicDialogRef | undefined;

  constructor(public dialogService: DialogService,) { }

  ngOnInit() {
  }

  addChildClick(item: DepartmentModel) {
    this.onAddChildClick.emit(item);
  }

}
