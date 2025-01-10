import { Component } from '@angular/core';
import { AddRoleComponent } from '../../../components/add-role/add-role.component';

@Component({
  selector: 'app-create-role-page',
  standalone: true,
  imports: [AddRoleComponent],
  templateUrl: './create-role-page.component.html',
  styleUrl: './create-role-page.component.scss'
})
export class CreateRolePageComponent {

}
