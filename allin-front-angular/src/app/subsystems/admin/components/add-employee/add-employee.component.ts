import { Component } from '@angular/core';
import { BasicModule } from '../../../../core/basic.module';
import { CalendarModule } from 'primeng/calendar';
import { SelectButtonModule } from 'primeng/selectbutton';
import { AccordionModule } from 'primeng/accordion';
import { ExtendedFieldModel } from '../../../shared/models/extended-fields-model';
import { ExtendedFieldsComponent } from '../../../shared/components/extended-fields/extended-fields.component';
import { ExtendedFieldTableNamesEnum } from '../../../shared/models/enums/extended-field-table-enum';
import { ExtendedFieldValueModel } from '../../../shared/models/extended-field-value-model';
import { FormBuilder, Validators } from '@angular/forms';
import { CreateEmployeeCommand } from '../../models/commands/create-employee-command';

@Component({
  selector: 'app-add-employee',
  standalone: true,
  imports: [BasicModule, CalendarModule, SelectButtonModule, AccordionModule, ExtendedFieldsComponent],
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.scss'
})
export class AddEmployeeComponent {
  TableNamesEnum = ExtendedFieldTableNamesEnum;

  value: string | undefined;
  date: Date | undefined;
  tableName: string = "employee";
  extendedFields: ExtendedFieldModel[] = [];

  floatingOptions: any[] = [{ label: 'Floating', value2: 'Floating' }, { label: 'Fixed', value2: 'Fixed' }];
  value2: string = 'Fixed';

  extendedFieldsValue?: ExtendedFieldValueModel[];

  form = this.fb.group({
    employeeCode: this.fb.control<string | null>(null),
    positionId: this.fb.control<number | null>(null),
    departmentId: this.fb.control<number | null>(null),
    personId: this.fb.control<number | null>(null),
  })


  constructor(public fb: FormBuilder) {

  }
  ngOnInit() {
    this.form.valueChanges.subscribe(x => {
      let command: CreateEmployeeCommand = {
        ...<CreateEmployeeCommand>this.form.getRawValue(),
        extendedFieldValues: this.extendedFieldsValue
      };

      // emit command to output
    })
  }


}
