
import { QueryCondition } from "./query-condition.model";
import { FieldTypesEnum, TableColumnBase, TableDropDownColumn } from "./table-column-model";

export class QueryFilter {

    constructor(init: (Partial<QueryFilter> & Pick<QueryFilter, 'column' | 'condition' | 'value'>)) {
        Object.assign(this, init);
        this.column = init.column;
        this.condition = init.condition;
        // if (init.value instanceof SqDateTime)
        //     this.value = SqDateTime.parse((<SqDateTime><any>init.value).excludeTimeZone, (<SqDateTime><any>init.value).date);
        // if (init.value2 instanceof SqDateTime)
        //     this.value2 = SqDateTime.parse((<SqDateTime><any>init.value).excludeTimeZone, (<SqDateTime><any>init.value).date)
    }
    value?: any;
    condition: Condition;

    value2?: any;
    condition2?: Condition;

    column: TableColumnBase;

    toServerCondition(): QueryCondition[] {
        const conditions: QueryCondition[] = [];
        conditions.push({
            propertyName: this.column.fieldType() == FieldTypesEnum.DropDown ? (this.column as TableDropDownColumn).valueFieldName : this.column.fieldName,
            comparison: this.condition.operator,
            values: this.value instanceof Array ? this.value : [this.value],
        });
        if (this.value2 && this.condition2)
            conditions.push({
                propertyName: this.column.fieldType() == FieldTypesEnum.DropDown ? (this.column as TableDropDownColumn).valueFieldName : this.column.fieldName,
                comparison: this.condition2.operator,
                values: this.value2 instanceof Array ? this.value2 : [this.value2],
            });
        return conditions;
    }
}

//Just add an object into the below array, if you want a new condition; the name and operator properties have to be unique
export const CONDITIONS_LIST = [
    { name: "EqualTo", label: "Equal to", symbol: "=", operator: "e" },
    { name: "Contains", label: "Contains", symbol: "Contains", operator: "contains" },
    { name: "NotEqual", label: "Not Equal", symbol: "<>", operator: "ne" },
    { name: "GreaterThan", label: "Greater than", symbol: ">", operator: "gt" },
    { name: "GreaterThanOrEqualTo", label: "Greater or equal", symbol: ">=", operator: "gte" },
    { name: "LessThan", label: "Less than", symbol: "<", operator: "lt" },
    { name: "LessThanOrEqual", label: "Less or equal", symbol: "<=", operator: "lte" },
    { name: "IsNull", label: "Is Null", symbol: "Is Null", operator: "n" },
    { name: "IsNotNull", label: "Is not Null", symbol: "Not Null", operator: "nn" },
] as const;

type OperatorName = typeof CONDITIONS_LIST[number]['name'];
type Operator = typeof CONDITIONS_LIST[number]['operator'];
type OperatorLabel = typeof CONDITIONS_LIST[number]['label'];
type OperatorSymbol = typeof CONDITIONS_LIST[number]['symbol'];

interface Condition { name: OperatorName, label: OperatorLabel, symbol: OperatorSymbol, operator: Operator };

interface ConditionOperatorSource extends Record<OperatorName | Operator, Condition> {
    // All: Condition[]
};

export const ConditionOperators = CONDITIONS_LIST.reduce((acc, item) =>
    (acc[item.name as OperatorName] = item, acc[item.operator as Operator] = item, acc), {} as ConditionOperatorSource
);

export const CONDITIONS_FUNCTIONS = { // search method base on conditions list value
    "is-empty": function (value: any, filteredValue: any) {
        return value === "";
    },
    "is-not-empty": function (value: any, filteredValue: any) {
        return value !== "";
    },
    "is-equal": function (value: any, filteredValue: any) {
        return value == filteredValue;
    },
    "is-not-equal": function (value: any, filteredValue: any) {
        return value != filteredValue;
    }
};
