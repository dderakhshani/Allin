import { CommonModule } from '@angular/common';
import { Component, ContentChild, ContentChildren, effect, EventEmitter, Input, input, Output, QueryList, signal, Signal, TemplateRef } from '@angular/core';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { TagModule } from 'primeng/tag';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { MultiSelectModule } from 'primeng/multiselect';
import { Table, TableFilterEvent, TableLazyLoadEvent, TableModule, TablePageEvent, TableRowCollapseEvent, TableRowExpandEvent } from 'primeng/table';
import { BooleanColumnDisplayEnum, FieldTypesEnum, FilterControlEnum, TableBooleanColumn, TableColumnBase, TableDropDownColumn } from './models/table-column-model';
import { AsPipe } from '../../pipes/as.pipe';
import { FormsModule } from '@angular/forms';
import { ToolbarModule } from 'primeng/toolbar';
import { ButtonModule } from 'primeng/button';
import { __values } from 'tslib';
import { ObservableOrArrayPipe } from '../../pipes/observable-array.pipe';
import { TableConfigOptions } from './models/table-config-options';
import { CheckboxModule } from 'primeng/checkbox';
import { QueryFilterHelper } from './models/query-filter.model';
import { ServerQueryCondition, QueryPaging, QueryParamModel, FilterQueryCondition } from "./models/query.models";
import { PagedList } from './models/paged-list';
import { BaseHttpService, UrlSegments } from '../../services/base.http.service';
import { finalize, tap } from 'rxjs';
import { DataTableFiltersHeaderComponent } from './data-table-filters-header/data-table-filters-header.component';

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
        ObservableOrArrayPipe,
        DataTableFiltersHeaderComponent
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

    @ContentChild('expandedRow', { static: true }) contentTemplate?: TemplateRef<any>;

    public columnsTemplateMap: Map<string, TemplateRef<any>> = new Map();
    @ContentChildren(TemplateRef, { descendants: true })
    private columnsTemplatesQueryList!: QueryList<TemplateRef<any>>;

    @Input()
    public configOptions: TableConfigOptions = new TableConfigOptions();

    @Input()
    public columns!: TableColumnBase[];

    @Input()
    dataApiUrl?: UrlSegments;

    @Input()
    public loading: boolean = false;

    @Input()
    public emptymMessage = "No records to display";//TODO: translate

    @Input()
    fetchDataTrigger = signal<boolean>(true);

    @Input()
    public isRowselectable?: boolean = true;

    @Input()
    public isRowExapandable?: boolean = false;

    @Output()
    onRowExpand = new EventEmitter<any>();

    @Output()
    onRowCollapse = new EventEmitter<any>();

    manipulateDataCallback?: (value: PagedList<any[]>) => PagedList<any[]>;

    queryPaging: QueryPaging = {
        pageSize: 10,
        pageIndex: 0
    };
    totalCount?: number;
    _dataSource: any[] = [];
    @Input()
    public set dataSource(value: any[]) {
        this._dataSource = value;

    }



    expandedRows = {};

    constructor(private httpService: BaseHttpService) {
        if (this.dataApiUrl)
            this.configOptions.internaLoadFetch = true;
        effect(() => {
            // this.getDataFromServer();
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
        });
    }

    get getGlobalFilterable() {
        return this.columns.filter(x => x.filterOptions?.globalFilterable == true).map(x => x.fieldName);
    }

    pageChanged(e: TablePageEvent) {
        this.queryPaging.pageIndex = e.first;
        this.queryPaging.pageSize = e.rows;
    }


    currentFilters: FilterQueryCondition[] = [];
    filterChanged(e: TableFilterEvent) {
        this.currentFilters = [];
        for (var key in e.filters) {
            const qc = new QueryFilterHelper(this.columns.find(x => x.fieldName == key)!, e.filters[key]).toFilterCondition();
            if (qc && qc.length) {
                this.currentFilters = this.currentFilters ?? {};
                this.currentFilters = [... this.currentFilters, ...qc];
            }

        }
    }

    public onHeaderFiltersChanged(filters: any) {
        this.currentFilters = filters;
        this.queryPaging.pageIndex = 0;
        if (this.configOptions.internaLoadFetch)
            this.getDataFromServer({});
    }

    getDataFromServer(event: TableLazyLoadEvent) {

        let conditions: ServerQueryCondition[] = [];
        for (var key in event.filters) {
            const qc = new QueryFilterHelper(this.columns.find(x => x.fieldName == key)!, event.filters[key]).toServerCondition();
            if (qc && qc.length) {
                conditions = [...conditions, ...qc];
            }

        }

        const queryParams = <QueryParamModel>{
            pagingProperties: this.queryPaging,
            group: "",
            columnsNamesToShow: [],
            conditions: conditions,
            orderByProperties: event.multiSortMeta?.map(x => x.field + " " + (x.order == 1 ? "asc" : "desc")).join(", ").trim() ?? "",
            searchTerm: event.globalFilter
        };

        this.loading = true;
        if (this.dataApiUrl?.queryStringParams)
            this.dataApiUrl.queryStringParams = { ...this.dataApiUrl.queryStringParams, ... this.convertToQueryString(queryParams) };
        else if (this.dataApiUrl)
            this.dataApiUrl.queryStringParams = this.convertToQueryString(queryParams);

        this.httpService.getData<PagedList<any[]>>(this.dataApiUrl!)
            .pipe(
                tap(result => {
                    this.dataSource = result.data;
                    this.totalCount = result.totalCount;
                    this.manipulateDataCallback && this.manipulateDataCallback(result);
                }),
                finalize(() => this.loading = false)
            )
            .subscribe(result => {

            });
    }


    clear(table: Table) {
        table.clear();
    }

    getColumnTemplate(templateRefId: string): TemplateRef<any> {
        return this.columnsTemplateMap.get(templateRefId)!;
    }

    rowExpand(event: TableRowExpandEvent) {
        this.onRowExpand.emit(event.data);
    }

    rowCollapse(event: TableRowCollapseEvent) {
        this.onRowCollapse.emit(event.data);
    }


    private convertToQueryString(queryParam: QueryParamModel): { [key: string]: string | number | boolean } {
        const queryStringParams: { [key: string]: string | number | boolean } = {};
        if (queryParam.pagingProperties) {
            queryStringParams['pagingProperties'] = JSON.stringify(queryParam.pagingProperties);
        }

        if (queryParam.group) {
            queryStringParams['group'] = queryParam.group;
        }

        if (queryParam.orderByProperties) {
            queryStringParams['orderByProperties'] = queryParam.orderByProperties;
        }

        if (queryParam.columnsNamesToShow) {
            queryStringParams['columnsNamesToShow'] = JSON.stringify(queryParam.columnsNamesToShow);
        }
        if (queryParam.conditions) {
            // replace('},', '}@') : Please note that,this is a contract between the Front-end and Back-end
            queryStringParams['conditions'] = JSON.stringify(queryParam.conditions).replace(/},/g, '}@');
        }
        if (queryParam.searchTerm)
            queryStringParams['searchTerm'] = queryParam.searchTerm;
        else
            queryStringParams['searchTerm'] = '';

        return queryStringParams;
    }

}
