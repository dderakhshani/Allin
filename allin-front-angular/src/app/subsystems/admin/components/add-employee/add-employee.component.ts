import { Component } from '@angular/core';
import { BasicModule } from '../../../../core/basic.module';
import { CalendarModule } from 'primeng/calendar';
import { SelectButtonModule } from 'primeng/selectbutton';
import { AccordionModule } from 'primeng/accordion';

@Component({
  selector: 'app-add-employee',
  standalone: true,
  imports: [BasicModule,CalendarModule,SelectButtonModule,AccordionModule,],
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.scss'
})
export class AddEmployeeComponent {
  value: string | undefined;
  date: Date | undefined;

  floatingOptions: any[] = [{ label: 'Floating', value2: 'Floating' }, { label: 'Fixed', value2: 'Fixed' }];
    value2: string = 'Fixed';

}
