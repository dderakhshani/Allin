import { CommonModule } from '@angular/common';
import { Component, ContentChildren, effect, Input, input, QueryList, signal, Signal, TemplateRef } from '@angular/core';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { TagModule } from 'primeng/tag';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { MultiSelectModule } from 'primeng/multiselect';
import { Table, TableModule } from 'primeng/table';
import { BooleanColumnDisplayEnum, FieldTypesEnum, FilterControlEnum, TableBooleanColumn, TableColumnBase, TableDropDownColumn } from './models/table-column-model';
import { AsPipe } from '../../pipes/as.pipe';
import { FormsModule } from '@angular/forms';
import { ToolbarModule } from 'primeng/toolbar';
import { ButtonModule } from 'primeng/button';
import { __values } from 'tslib';
import { ObservableOrArrayPipe } from '../../pipes/observable-array.pipe';
import { TableConfigOptions } from './models/table-config-options';
import { CheckboxModule } from 'primeng/checkbox';

@Component({
  selector: 'app-png-table',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    TableModule,
    ToolbarModule,
    ButtonModule,
    CheckboxModule,
    TagModule,
    IconFieldModule,
    InputTextModule,
    InputIconModule,
    MultiSelectModule,
    DropdownModule,
    AsPipe,
    ObservableOrArrayPipe
  ],
  templateUrl: './png-table.component.html',
  styleUrl: './png-table.component.scss'
})
export class PngTableComponent {
  fieldTypesEnum = FieldTypesEnum;
  tableBooleanColumn = TableBooleanColumn;
  booleanColumnDisplayEnum = BooleanColumnDisplayEnum;
  tableDropDownColumn = TableDropDownColumn;
  filterControlEnum = FilterControlEnum;

  @Input()
  public configOptions: TableConfigOptions = new TableConfigOptions();

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

  public columnsTemplateMap: Map<string, TemplateRef<any>> = new Map();
  @ContentChildren(TemplateRef, { descendants: true })
  private columnsTemplatesQueryList!: QueryList<TemplateRef<any>>;


  constructor() {
    effect(() => {
      this.fetchData();
    });
  }

  public ngAfterContentInit(): void {
    this.columnsTemplatesQueryList.forEach((template: any) => {
      const attributes = template._declarationTContainer.attrs || [];

      // Find the `templateForColumn` attribute
      const columnIdIndex = attributes.indexOf('templateForColumn') + 1;
      if (columnIdIndex > 0 && columnIdIndex < attributes.length) {
        const columnId = attributes[columnIdIndex];
        this.columnsTemplateMap.set(columnId, template);
      }
    });

    this.columnsTemplatesQueryList.changes.subscribe(() => {
      this.columnsTemplateMap = new Map();
      this.columnsTemplatesQueryList!.forEach((item: any) => {
        // this.columnsKeyTemplate[item.templateName] = item.template;
      });
    })

  }

  get getGlobalFilterable() {
    return this.columns.filter(x => x.filterOptions?.globalFilterable == true).map(x => x.fieldName);
  }

  fetchData() {

  }

  clear(table: Table) {
    table.clear();
  }

  getColumnTemplate(templateRefId: string): TemplateRef<any> {
    return this.columnsTemplateMap.get(templateRefId)!;
  }



}
