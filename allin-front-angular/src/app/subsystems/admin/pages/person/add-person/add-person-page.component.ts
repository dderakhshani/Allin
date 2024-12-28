import { Component } from '@angular/core';
import { AddPersonComponent } from '../../../components/add-person/add-person.component';

@Component({
  selector: 'app-add-person-page',
  standalone: true,
  imports: [AddPersonComponent],
  templateUrl: './add-person-page.component.html',
  styleUrl: './add-person-page.component.scss'
})
export class AddPersonPageComponent {

}
