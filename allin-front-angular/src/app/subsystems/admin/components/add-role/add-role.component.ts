import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MessageService } from 'primeng/api';
import { BasicModule } from '../../../../core/basic.module';
import { FormBuilder } from '@angular/forms';
import { CreateRoleCommand } from '../../models/commands/create-role-command';
import { PngTableComponent } from '../../../../core/components/png-table/png-table.component';
import { BooleanColumnDisplayEnum, TableBooleanColumn, TableColumnBase, TableTextColumn } from '../../../../core/components/png-table/models/table-column-model';
import { Customer } from '../../pages/user/user-list/user-list-page.component';

@Component({
  selector: 'app-add-role',
  standalone: true,
  imports: [BasicModule,
    PngTableComponent
  ],
  providers: [MessageService],
  templateUrl: './add-role.component.html',
  styleUrl: './add-role.component.scss'
})
export class AddRoleComponent {

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
