import { Component } from '@angular/core';
import { TableNameModel } from '../../../models/queries/extendedfield-model';

@Component({
  selector: 'app-create-extended-field-page',
  standalone: true,
  imports: [],
  templateUrl: './create-extended-field-page.component.html',
  styleUrl: './create-extended-field-page.component.scss'
})
export class CreateExtendedFieldPageComponent {


    tableNames: TableNameModel[] = [];

}
