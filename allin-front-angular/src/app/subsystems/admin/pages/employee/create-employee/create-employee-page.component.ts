import { Component } from '@angular/core';
import { AddEmployeeComponent } from '../../../components/add-employee/add-employee.component';

@Component({
    selector: 'app-create-employee-page',
    standalone: true,
    imports: [AddEmployeeComponent],
    templateUrl: './create-employee-page.component.html',
    styleUrl: './create-employee-page.component.scss'
})
export class CreateEmployeePageComponent {

}
