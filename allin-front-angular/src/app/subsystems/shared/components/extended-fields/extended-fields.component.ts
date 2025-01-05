import { Component, Input, input } from '@angular/core';
import { ExtendedFieldTableNames } from '../../models/enums/extended-field-table-enum';
import { ExtendedFieldModel } from '../../models/extended-fields-model';

@Component({
  selector: 'app-extended-fields',
  standalone: true,
  imports: [],
  templateUrl: './extended-fields.component.html',
  styleUrl: './extended-fields.component.scss'
})
export class ExtendedFieldsComponent {

  @Input()
  tableName!: ExtendedFieldTableNames;

  fields!: ExtendedFieldModel[];

}
