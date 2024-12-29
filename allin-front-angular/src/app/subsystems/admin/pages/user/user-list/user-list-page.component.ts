import { Component } from '@angular/core';
import { PngTableComponent } from '../../../../../core/components/png-table/png-table.component';
import { BasicModule } from '../../../../../core/basic.module';
import { TableBooleanColumn, TableColumnBase, TableTextColumn } from '../../../../../core/components/png-table/models/table-column-model';
import { Table } from 'primeng/table';
import { UserService } from '../../../apis/user.service';
import { TagModule } from 'primeng/tag';

@Component({
  selector: 'app-user-list-page',
  standalone: true,
  imports: [
    BasicModule,
    PngTableComponent,
    TagModule],
  templateUrl: './user-list-page.component.html',
  styleUrl: './user-list-page.component.scss'
})
export class UserListPageComponent {

  columns: TableColumnBase[] = [
    new TableTextColumn({
      title: 'Name',
      rootFieldName: 'name',
      sortable: false,
    }),
    new TableTextColumn({
      title: 'Country',
      rootFieldName: 'country',
      templateRefId: 'countryColumnTemplate',
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
    })
  ];

  customers!: Customer[];
  representatives!: Representative[];

  statuses!: any[];

  loading: boolean = true;

  activityValues: number[] = [0, 100];

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getCustomersLarge().then((customers) => {
      this.customers = customers;
      this.loading = false;

      this.customers.forEach((customer) => (customer.date = new Date(<Date>customer.date)));
    });

    this.representatives = [
      { name: 'Amy Elsner', image: 'amyelsner.png' },
      { name: 'Anna Fali', image: 'annafali.png' },
      { name: 'Asiya Javayant', image: 'asiyajavayant.png' },
      { name: 'Bernardo Dominic', image: 'bernardodominic.png' },
      { name: 'Elwin Sharvill', image: 'elwinsharvill.png' },
      { name: 'Ioni Bowcher', image: 'ionibowcher.png' },
      { name: 'Ivan Magalhaes', image: 'ivanmagalhaes.png' },
      { name: 'Onyama Limba', image: 'onyamalimba.png' },
      { name: 'Stephen Shaw', image: 'stephenshaw.png' },
      { name: 'Xuxue Feng', image: 'xuxuefeng.png' }
    ];

    this.statuses = [
      { label: 'Unqualified', value: 'unqualified' },
      { label: 'Qualified', value: 'qualified' },
      { label: 'New', value: 'new' },
      { label: 'Negotiation', value: 'negotiation' },
      { label: 'Renewal', value: 'renewal' },
      { label: 'Proposal', value: 'proposal' }
    ];
  }


  getSeverity(status: string) {
    switch (status) {
      case 'unqualified':
        return 'danger';

      case 'qualified':
        return 'success';

      case 'new':
        return 'info';

      case 'negotiation':
        return 'warning';

      default:
        return 'info';
    }
  }
}

export interface Country {
  name?: string;
  code?: string;
}

export interface Representative {
  name?: string;
  image?: string;
}

export interface Customer {
  id?: number;
  name?: string;
  country?: Country;
  company?: string;
  date?: string | Date;
  status?: string;
  activity?: number;
  representative?: Representative;
  verified?: boolean;
  balance?: number;
}
