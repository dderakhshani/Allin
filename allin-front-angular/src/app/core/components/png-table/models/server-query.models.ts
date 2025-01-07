export interface QueryCondition {
    propertyName: string
    comparison: string
    values: any[]
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
