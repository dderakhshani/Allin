
import { FilterMetadata } from "primeng/api";
import { QueryCondition } from "./server-query.models";

export class QueryFilterHelper {

    filter: FilterMetadata | FilterMetadata[] | undefined;
    fieldName: string;

    constructor(fieldName: string, init: FilterMetadata | FilterMetadata[] | undefined) {

        this.filter = init;
        this.fieldName = fieldName;
    }


    toServerCondition(): QueryCondition[] | null {
        let filters: FilterMetadata[] = [];

        if (!this.filter)
            return null;

        if (this.filter instanceof Array)
            filters = this.filter;
        else
            filters = [this.filter];

        const conditions: QueryCondition[] = [];

        filters.forEach(f => {
            conditions.push({
                propertyName: this.fieldName,
                comparison: f.operator!,
                values: [f.value],
            });
        })

        return conditions;
    }
}

//Just add an object into the below array, if you want a new condition; the name and operator properties have to be unique
export const CONDITIONS_LIST = [
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

export declare class FilterMatchMode {
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

type OperatorName = typeof CONDITIONS_LIST[number]['name'];
type Operator = typeof CONDITIONS_LIST[number]['operator'];
type OperatorSymbol = typeof CONDITIONS_LIST[number]['symbol'];

interface Condition { name: OperatorName, symbol: OperatorSymbol, operator: Operator };

interface ConditionOperatorSource extends Record<OperatorName | Operator, Condition> {
    // All: Condition[]
};

export const ConditionOperators = CONDITIONS_LIST.reduce((acc, item) =>
    (acc[item.name as OperatorName] = item, acc[item.operator as Operator] = item, acc), {} as ConditionOperatorSource
);

