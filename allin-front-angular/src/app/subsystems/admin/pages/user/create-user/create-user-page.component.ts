import { Component } from '@angular/core';
import { AddPersonComponent } from '../../../components/add-person/add-person.component';
import { BasicModule } from '../../../../../core/basic.module';


@Component({
  selector: 'app-create-user-page',
  standalone: true,
  imports: [BasicModule, AddPersonComponent],
  templateUrl: './create-user-page.component.html',
  styleUrl: './create-user-page.component.scss'
})
export class CreateUserPageComponent {

}
