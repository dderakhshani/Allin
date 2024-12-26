import { QueryCondition } from "./query-condition.model";
import { QueryPaging } from "./query-paging.model";

export interface QueryParamModel {
    pagingProperties?: QueryPaging;
    group?: string;
    orderByProperties?: string;
    conditions?: QueryCondition[];
    columnsNamesToShow: string[];
    searchTerm?: string;
}
