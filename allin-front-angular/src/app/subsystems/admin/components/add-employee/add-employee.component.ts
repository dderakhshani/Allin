import { Component, EventEmitter, Input, Output } from '@angular/core';
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
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-add-employee',
  standalone: true,
  imports: [BasicModule,
    CalendarModule,
    SelectButtonModule,
    AccordionModule,
    ExtendedFieldsComponent],
  providers: [MessageService],
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.scss'
})
export class AddEmployeeComponent {
  tableName = ExtendedFieldTableNamesEnum.Employee;

  @Input()
  showValidationWarning = true;

  @Output()
  commandChange = new EventEmitter<CreateEmployeeCommand | null>();

  extendedFields: ExtendedFieldModel[] = [];
  extendedFieldsValue?: ExtendedFieldValueModel[];

  form = this.fb.group({
    personId: this.fb.control<number | null>(null),
    employeeCode: this.fb.control<string | null>(null),
    departmentPositionId: this.fb.control<number | null>(null),
    employmentDate: this.fb.control<Date | null>(null),
    contractTypeBaseId: this.fb.control<number | null>(null),
    floating: this.fb.control<boolean | null>(null),
  })

  floatingOptions: any[] = [{ label: 'Floating', value2: 'Floating' }, { label: 'Fixed', value2: 'Fixed' }];

  constructor(private messageService: MessageService,
    public fb: FormBuilder) {

  }
  ngOnInit() {

    this.form.valueChanges.subscribe(x => {
      if (this.form.valid) {
        let command: CreateEmployeeCommand = {
          ...<CreateEmployeeCommand>this.form.getRawValue(),
          extendedFieldValues: this.extendedFieldsValue ?? [],
        };

        // emit command to output
        this.commandChange.emit(command);
      }
      else {
        if (this.showValidationWarning)
          this.messageService.add({ severity: 'warn', summary: 'Warn', detail: 'Please fix the errors' });//TODO: translate
        this.commandChange.emit(null);
      }
    })

  }


}
