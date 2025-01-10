import { Component, Input } from '@angular/core';
import { TreeNode } from 'primeng/api';
import { TreeTableModule } from 'primeng/treetable';
import { DepartmentModel } from '../../../../models/queries/department-model';

@Component({
  selector: 'app-department-grid',
  standalone: true,
  imports: [TreeTableModule],
  templateUrl: './department-grid.component.html',
  styleUrl: './department-grid.component.scss'
})
export class DepartmentGridComponent {

  @Input()
  data?: TreeNode<DepartmentModel>[];

  constructor() { }

  ngOnInit() {
  }

}
