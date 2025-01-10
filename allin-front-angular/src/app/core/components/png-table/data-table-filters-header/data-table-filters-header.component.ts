
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QueryCondition } from '../models/server-query.models';
import { Chip } from 'primeng/chip';
import { FieldTypesEnum, TableColumnBase, TableDropDownColumn } from '../models/table-column-model';
import { BasicModule } from '../../../basic.module';

@Component({
    selector: 'c-data-table-filters-header',
    templateUrl: './data-table-filters-header.component.html',
    styleUrls: ['./data-table-filters-header.component.scss'],
    standalone: true,
    imports: [
        BasicModule,
        Chip
    ]
})
export class DataTableFiltersHeaderComponent implements OnInit {

    FieldTypes = FieldTypesEnum;

    Object = Object;
    @Input()
    filters?: { [key: string]: QueryCondition };
    @Output()
    filtersChanged = new EventEmitter<any>();

    constructor() { }

    ngOnInit(): void {
    }

    removeFilter(key: any) {
        if (this.filters) {
            delete this.filters[key];
            this.filtersChanged.emit(this.filters);
        }
    }

    removeAll() {
        this.filters = {};
        this.filtersChanged.emit(this.filters);
    }


    getItemsSourceValue(column: TableDropDownColumn, items: any[], value: any) {
        if (!column.multiple) {
            const item = items.find((x: any) => x.value == value);
            return item[column.itemsSource?.displayFieldName ?? 0];
        }

        const filterItems = items.filter((x: any) => value.indexOf(x.value) !== -1);
        return items.map((item: any) => item[column.itemsSource?.displayFieldName ?? 0]).join(', ');
    }

}







