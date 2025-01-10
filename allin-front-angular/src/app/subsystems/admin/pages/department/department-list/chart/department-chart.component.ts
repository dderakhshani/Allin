import { Component, Input } from '@angular/core';
import { TreeNode } from 'primeng/api';
import { OrganizationChartModule } from 'primeng/organizationchart';
import { DepartmentModel } from '../../../../models/queries/department-model';
@Component({
  selector: 'app-department-chart',
  standalone: true,
  imports: [OrganizationChartModule],
  templateUrl: './department-chart.component.html',
  styleUrl: './department-chart.component.scss'
})
export class DepartmentChartComponent {

  @Input()
  data?: TreeNode<DepartmentModel>[];

}
