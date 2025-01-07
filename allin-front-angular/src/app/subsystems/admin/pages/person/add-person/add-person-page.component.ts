import { Component, Input } from '@angular/core';
import { AddPersonComponent } from '../../../components/add-person/add-person.component';
import { CreatePersonCommand } from '../../../models/commands/create-Person-command';
import { PersonService } from '../../../apis/person.service';
import { BasicModule } from '../../../../../core/basic.module';

@Component({
  selector: 'app-add-person-page',
  standalone: true,
  imports: [BasicModule, AddPersonComponent,],
  templateUrl: './add-person-page.component.html',
  styleUrl: './add-person-page.component.scss'
})
export class AddPersonPageComponent {


  command!: CreatePersonCommand;

  constructor(private personService: PersonService) { }

  saveData() {

    this.personService.create(this.command).subscribe(
      (response) => {
        console.log('اطلاعات با موفقیت ذخیره شد:', response);
      },
      (error) => {
        console.error('خطا در ذخیره اطلاعات:', error);
      }
    );
  }

}
