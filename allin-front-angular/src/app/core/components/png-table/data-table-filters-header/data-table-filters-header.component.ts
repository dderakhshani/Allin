
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterQueryCondition } from '../models/query.models';
import { Chip } from 'primeng/chip';
import { FieldTypesEnum, TableColumnBase, TableDropDownColumn } from '../models/table-column-model';
import { BasicModule } from '../../../basic.module';
import { AsPipe } from '../../../pipes/as.pipe';
import { ObservableOrArrayPipe } from '../../../pipes/observable-array.pipe';

@Component({
    selector: 'c-data-table-filters-header',
    templateUrl: './data-table-filters-header.component.html',
    styleUrls: ['./data-table-filters-header.component.scss'],
    standalone: true,
    imports: [
        BasicModule,
        Chip,
        AsPipe,
        ObservableOrArrayPipe
    ]
})
export class DataTableFiltersHeaderComponent implements OnInit {

    tableDropDownColumn = TableDropDownColumn;
    FieldTypes = FieldTypesEnum;

    Object = Object;
    @Input()
    filters?: FilterQueryCondition[];
    @Output()
    filtersChanged = new EventEmitter<any>();

    constructor() { }

    ngOnInit(): void {
    }

    removeFilter(index: number) {
        if (this.filters) {
            this.filters.splice(index, 1);
            this.filtersChanged.emit(this.filters);
        }
    }

    removeAll() {
        this.filters = [];
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







