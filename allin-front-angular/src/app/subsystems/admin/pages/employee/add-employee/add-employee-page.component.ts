import { Component } from '@angular/core';
import { AddEmployeeComponent } from '../../../components/add-employee/add-employee.component';

@Component({
  selector: 'app-add-employee-page',
  standalone: true,
  imports: [AddEmployeeComponent],
  templateUrl: './add-employee-page.component.html',
  styleUrl: './add-employee-page.component.scss'
})
export class AddEmployeePageComponent {

}
