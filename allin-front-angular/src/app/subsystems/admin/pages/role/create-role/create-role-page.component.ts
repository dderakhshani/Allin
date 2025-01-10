import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Customer } from '../../user/user-list/user-list-page.component';
import { BooleanColumnDisplayEnum, TableBooleanColumn, TableColumnBase, TableTextColumn } from '../../../../../core/components/png-table/models/table-column-model';
import { CreateRoleCommand } from '../../../models/commands/create-role-command';
import { MessageService } from 'primeng/api';
import { FormBuilder } from '@angular/forms';
import { BasicModule } from '../../../../../core/basic.module';
import { PngTableComponent } from '../../../../../core/components/png-table/png-table.component';

@Component({
  selector: 'app-create-role-page',
  standalone: true,
  imports: [BasicModule,
    PngTableComponent],
  providers: [MessageService],
  templateUrl: './create-role-page.component.html',
  styleUrl: './create-role-page.component.scss'
})
export class CreateRolePageComponent {

  roles!: Customer[];//todo: cheange table data

  columns: TableColumnBase[] = [
    new TableTextColumn({
      title: 'Name',
      rootFieldName: 'name',
      sortable: false,
    }),
    new TableTextColumn({
      title: 'Last Name',
      rootFieldName: 'country',
      sortable: false,
    }),
    new TableTextColumn({
      title: 'Agent',
      rootFieldName: 'agent',
      sortable: false,
    }),
    new TableTextColumn({
      title: 'Status',
      rootFieldName: 'status',
      templateRefId: 'statusColumnTemplate',
      sortable: false,
    }),
    new TableBooleanColumn({
      title: 'Verified',
      rootFieldName: 'verified',
      sortable: false,
      displayStyle: BooleanColumnDisplayEnum.OnlyCheckColorFull
    })
  ];

  @Input()
  showValidationWarning = true;

  @Output()
  commandChange = new EventEmitter<CreateRoleCommand | null>();

  form = this.fb.group({
    title: this.fb.control<string | null>(null),
    uniqueName: this.fb.control<string | null>(null),
    description: this.fb.control<string | null>(null),
    departmentId: this.fb.control<number | null>(null),
    permissionIds: this.fb.control<[number] | null>(null),
  })


  constructor(private messageService: MessageService,
    public fb: FormBuilder) {

  }

}
