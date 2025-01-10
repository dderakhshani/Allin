import { OperatorModel } from "./query-filter.model";
import { TableColumnBase } from "./table-column-model";

export interface QueryCondition {
    propertyName: string;
    comparison: string;
    values: any[];

    column: TableColumnBase;
    operator: OperatorModel;
}

export interface QueryPaging {
    pageSize: number;
    pageIndex: number;
}


export interface QueryParamModel {
    pagingProperties?: QueryPaging;
    group?: string;
    orderByProperties?: string;
    conditions?: QueryCondition[];
    columnsNamesToShow: string[];
    searchTerm?: string;
}
