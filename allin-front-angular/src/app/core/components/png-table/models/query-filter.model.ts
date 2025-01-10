
import { FilterMetadata } from "primeng/api";
import { FilterQueryCondition, ServerQueryCondition } from "./query.models";
import { TableColumnBase } from "./table-column-model";

export class QueryFilterHelper {

    filter: FilterMetadata | FilterMetadata[] | undefined;
    column: TableColumnBase;

    constructor(column: TableColumnBase, init: FilterMetadata | FilterMetadata[] | undefined) {

        this.filter = init;
        this.column = column;
    }


    toServerCondition(): ServerQueryCondition[] | null {
        let filters: FilterMetadata[] = [];

        if (!this.filter)
            return null;

        if (this.filter instanceof Array)
            filters = this.filter;
        else
            filters = [this.filter];

        const conditions: ServerQueryCondition[] = [];

        filters.forEach(f => {
            if (f.value)
                conditions.push({
                    propertyName: this.column.fieldName,
                    comparison: f.matchMode!,
                    values: [f.value],
                });
        })

        return conditions;
    }

    toFilterCondition(): FilterQueryCondition[] | null {
        let filters: FilterMetadata[] = [];

        if (!this.filter)
            return null;

        if (this.filter instanceof Array)
            filters = this.filter;
        else
            filters = [this.filter];

        const conditions: FilterQueryCondition[] = [];

        filters.forEach(f => {
            if (f.value)
                conditions.push({
                    operator: CONDITIONS_DICT[f.matchMode!],
                    values: [f.value],
                    column: this.column
                });
        })

        return conditions;
    }
}


export class FilterMatchMode {
    static readonly STARTS_WITH = "startsWith";
    static readonly NOT_CONTAINS = "notContains";
    static readonly ENDS_WITH = "endsWith";
    static readonly IN = "in";
    static readonly BETWEEN = "between";
    static readonly IS = "is";
    static readonly IS_NOT = "isNot";
    static readonly BEFORE = "before";
    static readonly AFTER = "after";
    static readonly DATE_IS = "dateIs";
    static readonly DATE_IS_NOT = "dateIsNot";
    static readonly DATE_BEFORE = "dateBefore";
    static readonly DATE_AFTER = "dateAfter";
}

//Just add an object into the below array, if you want a new condition; the name and operator properties have to be unique startsWith
export const CONDITIONS_LIST = [
    { name: FilterMatchMode.STARTS_WITH, symbol: "starts", operator: "sw" },
    { name: FilterMatchMode.ENDS_WITH, symbol: "ends", operator: "ew" },
    { name: "equals", symbol: "=", operator: "e" },
    { name: "notEquals", symbol: "<>", operator: "ne" },
    { name: "contains", symbol: "Contains", operator: "contains" },
    { name: "greaterThan", symbol: ">", operator: "gt" },
    { name: "greaterThanOrEqualTo", symbol: ">=", operator: "gte" },
    { name: "lessThan", symbol: "<", operator: "lt" },
    { name: "lessThanOrEqual", symbol: "<=", operator: "lte" },
    { name: "IsNull", symbol: "Is Null", operator: "n" },
    { name: "IsNotNull", symbol: "Not Null", operator: "nn" },
] as const;



type OperatorNames = typeof CONDITIONS_LIST[number]['name'];
type Operators = typeof CONDITIONS_LIST[number]['operator'];
type OperatorSymbols = typeof CONDITIONS_LIST[number]['symbol'];

export interface OperatorModel { name: OperatorNames, symbol: OperatorSymbols, operator: Operators };

export const CONDITIONS_DICT = CONDITIONS_LIST.reduce((acc, condition) => {
    acc[condition.name] = condition;
    return acc;
}, {} as Record<string, OperatorModel>);







