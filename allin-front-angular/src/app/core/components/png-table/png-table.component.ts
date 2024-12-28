import { CommonModule } from '@angular/common';
import { Component, effect, Input, input, signal, Signal } from '@angular/core';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { TagModule } from 'primeng/tag';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { MultiSelectModule } from 'primeng/multiselect';
import { Table, TableModule } from 'primeng/table';
import { FieldTypesEnum, TableColumnBase, TableDropDownColumn } from './models/table-column-model';
import { AsPipe } from '../../pipes/as.pipe';
import { FormsModule } from '@angular/forms';
import { ToolbarModule } from 'primeng/toolbar';
import { ButtonModule } from 'primeng/button';
import { __values } from 'tslib';

@Component({
  selector: 'app-png-table',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    TableModule,
    ToolbarModule,
    ButtonModule,
    TagModule,
    IconFieldModule,
    InputTextModule,
    InputIconModule,
    MultiSelectModule,
    DropdownModule,
    AsPipe
  ],
  templateUrl: './png-table.component.html',
  styleUrl: './png-table.component.scss'
})
export class PngTableComponent {
  fieldTypesEnum = FieldTypesEnum;
  tableDropDownColumn = TableDropDownColumn;

  @Input()
  public columns!: TableColumnBase[];

  @Input()
  public loading: boolean = false;

  @Input()
  public emptymMessage = "No records to display";

  @Input()
  fetchDataTrigger = signal<boolean>(true);

  _dataSource: any[] = [];
  @Input()
  public set dataSource(value: any[]) {
    this._dataSource = value;

  }

  get getGlobalFilterable() {
    return this.columns.filter(x => x.globalFilterable == true).map(x => x.fieldName);
  }

  constructor() {
    effect(() => {
      this.fetchData();
    });
  }

  fetchData() {

  }

}
