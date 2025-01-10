import { OperatorModel } from "./query-filter.model";
import { TableColumnBase } from "./table-column-model";

export interface ServerQueryCondition {
    propertyName: string;
    comparison: string;
    values: any[];

}

export interface FilterQueryCondition {
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
    conditions?: ServerQueryCondition[];
    columnsNamesToShow: string[];
    searchTerm?: string;
}
