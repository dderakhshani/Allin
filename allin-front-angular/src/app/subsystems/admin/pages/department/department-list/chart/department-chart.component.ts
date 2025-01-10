import { Component } from '@angular/core';
import { TreeNode } from 'primeng/api';
import { OrganizationChartModule } from 'primeng/organizationchart';
@Component({
  selector: 'app-department-chart',
  standalone: true,
  imports: [OrganizationChartModule],
  templateUrl: './department-chart.component.html',
  styleUrl: './department-chart.component.scss'
})
export class DepartmentChartComponent {
  data: TreeNode[] = [
    {
      label: 'F.C Barcelona',
      expanded: true,
      children: [
        {
          label: 'Argentina',
          expanded: true,
          children: [
            {
              label: 'Argentina'
            },
            {
              label: 'France'
            }
          ]
        },
        {
          label: 'France',
          expanded: true,
          children: [
            {
              label: 'France'
            },
            {
              label: 'Morocco'
            }
          ]
        }
      ]
    }
  ];
}
