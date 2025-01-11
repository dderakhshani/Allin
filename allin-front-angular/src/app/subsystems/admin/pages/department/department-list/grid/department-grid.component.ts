import { Component, Input } from '@angular/core';
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

  ref: DynamicDialogRef | undefined;

  constructor(public dialogService: DialogService,) { }

  ngOnInit() {
  }

  openAdd() {
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
