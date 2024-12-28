import { Validators } from '@angular/forms';
import { Observable } from 'rxjs';


type DataTableColumnSpecification<T, E = any> = Partial<Omit<TableColumnBase<T>, 'fieldType' | 'fieldName' | 'valueFieldName' | 'groupingField'>> &
    Pick<TableColumnBase<T>, 'title'> &
{
    fieldNameInRoot: Extract<keyof T, string>,
    fieldNameBelowRoot?: Extract<keyof E, string>,
    valueFieldNameInRoot?: Extract<keyof T, string>,
    valueFieldNameBelowRoot?: Extract<keyof E, string>,
    textFieldNameInRoot?: Extract<keyof T, string>,
    textFieldNameBelowRoot?: Extract<keyof E, string>,
    groupingFieldNameInRoot?: Extract<keyof T, string>,
    groupingFieldNameBelowRoot?: Extract<keyof E, string>,
    requiredFields?: { fieldNameInRoot: Extract<keyof T, string>, fieldNameBelowRoot?: Extract<keyof E, string> }[]
};

type DataTableColumnsAsObject<T> = { [key: string]: TableColumnBase<T> };

export const dataTableColumnsObjectToArray = <T>(columns: DataTableColumnsAsObject<T>): TableColumnBase<T>[] => {
    return Object.keys(columns).map(columnUniqueName => {
        columns[columnUniqueName].uniqueName = columnUniqueName;
        return columns[columnUniqueName];
    });
}

export abstract class TableColumnBase<T = any, E = any> {

    constructor(fieldType: FieldTypesEnum, init: DataTableColumnSpecification<T, E>) {
        Object.assign(this, init);

        this.title = init.title;

        this._fieldType = fieldType;
        this.fieldName = init.fieldNameInRoot;
        if (init.fieldNameBelowRoot) {
            this.fieldName += `.${init.fieldNameBelowRoot}`
        }

        this.requiredFieldNames = [];
        for (let requiredField of init.requiredFields ?? []) {
            let field = String(requiredField.fieldNameInRoot);
            if (requiredField.fieldNameBelowRoot) {
                field += `.${requiredField.fieldNameBelowRoot}`
            }
            this.requiredFieldNames.push(field);
        }

        if (init.groupingFieldNameInRoot) {
            this.groupingField = init.groupingFieldNameInRoot;
            if (init.groupingFieldNameBelowRoot) {
                this.groupingField += `.${init.groupingFieldNameBelowRoot}`;
            }
        } else {
            this.groupingField = this.fieldName;
        }

        if (!this.orderingFields)
            this.orderingFields = [this.fieldName];

        this.isDatabaseColumn = this._fieldType != FieldTypesEnum.SelectAction
            && this._fieldType != FieldTypesEnum.CopyPasteAction
            && (this._fieldType != FieldTypesEnum.WithTemplate || (this.fieldName != undefined && this.fieldName != null && this.fieldName != ''));



        this.uniqueName = this.fieldName + (Math.random() + 1).toString(36).substring(7);
    }
    // (to think about) Muhammad thinks it is better to define one class for each FieldType, because it is not obvious how to configure each DataTableColumn types, and which properties have to set, (we can only find out what to do by checking existing samples)
    //selected: boolean;
    public uniqueName: string;
    public title: string;
    public fieldName: string;
    public groupingField?: string;
    public orderingFields?: string[];
    protected _fieldType: FieldTypesEnum;

    public get fieldType() {
        return this._fieldType;
    }
    public displayFormat?: string;

    protected requiredFieldNames: string[];
    protected isDatabaseColumn?: boolean = true;
    public isDataColumn() {
        return this.isDatabaseColumn;
    }

    filterable: boolean | 'rowOnly' | 'cardOnly' = true;
    globalFilterable: boolean | 'rowOnly' | 'cardOnly' = true;

    public editable: boolean = false;
    public editableFieldName?: string;

    public enabled: true | false | 'rowOnly' | 'cardOnly' = true;
    public enabledFieldName?: string;

    public visible: true | false | 'rowOnly' | 'cardOnly' = true;
    public visibleFieldName?: string;

    public sortable: boolean | 'rowOnly' | 'cardOnly' = true;
    public groupable: boolean | 'rowOnly' | 'cardOnly' = true;
    public resizable: boolean = true;
    public rowTextAlign: 'left' | 'center' | 'right' = 'left';
    public headerTextAlign: 'left' | 'center' | 'right' = 'left';
    public showInFooter: boolean = false;

    public footerAggregateTemplateRefId?: string;
    public footerAggregate?: AggregatesTypesEnum;
    public footerAggregateOperator?: AggregatesOperatorsEnum = AggregatesOperatorsEnum.Source;

    public hint?: string;
    public width?: string;

    validators?: Validators;

    valueProviderCallback?: (dataItem: any, viewMode: any) => string;
    validatorsCallBack?: (dataItem: any) => Validators;
    editableCallBack?: (dataItem: any) => boolean;
    editableChangeValueCallBack?: (dataItem: any) => any;
    aggregateFooterTemplateCallback?: (value: number, column: TableColumnBase, dataItems: any[]) => string;

}

export class TableTextColumn<T = any, E = any> extends TableColumnBase<T, E> {

    constructor(init: DataTableColumnSpecification<T, E>) {
        super(FieldTypesEnum.Text, init);
    }

    placeholder?: string;
}

export class TableEmailColumn<T = any, E = any> extends TableColumnBase<T, E> {

    constructor(init: DataTableColumnSpecification<T, E>) {
        super(FieldTypesEnum.Email, init);
    }

    placeholder?: string;
}

export class TableBooleanColumn<T = any, E = any> extends TableColumnBase<T, E> {

    constructor(init: DataTableColumnSpecification<T, E>) {
        super(FieldTypesEnum.Boolean, init);
    }

}

export class TableDropDownColumn<T = any, E = any> extends TableColumnBase<T, E> {

    constructor(init: DataTableColumnSpecification<T, E>) {
        super(FieldTypesEnum.DropDown, init);

        if (init.textFieldNameInRoot) {
            this.textFieldName = init.textFieldNameInRoot;
            if (init.textFieldNameBelowRoot) {
                this.textFieldName += `.${init.textFieldNameBelowRoot}`;
            }
        } else {
            this.textFieldName = this.fieldName;
        }


        if (init.valueFieldNameInRoot) {
            this.valueFieldName = init.valueFieldNameInRoot;
            if (init.valueFieldNameBelowRoot) {
                this.valueFieldName += `.${init.valueFieldNameBelowRoot}`;
            }
        } else {
            this.valueFieldName = this.fieldName;
        }

        // if (this.fieldType === FieldTypesEnum.Enum && init.multiple === undefined)
        //     this.multiple = true;

    }

    public itemsSource?: DropDownDataSource;
    public valueFieldName: string;
    public textFieldName: string;
    multiple: boolean = false;
}

export class TableDateColumn<T = any, E = any> extends TableColumnBase<T, E> {

    constructor(init: DataTableColumnSpecification<T, E>) {
        super(FieldTypesEnum.Date, init);
    }

}

export class TableTimeColumn<T = any, E = any> extends TableColumnBase<T, E> {

    constructor(init: DataTableColumnSpecification<T, E>) {
        super(FieldTypesEnum.Time, init);
    }

}

export class TableTemplateColumn<T = any, E = any> extends TableColumnBase<T, E> {

    constructor(init: DataTableColumnSpecification<T, E>) {
        super(FieldTypesEnum.WithTemplate, init);
    }
    templateRefId?: string;
}

export class TableNumberColumn<T = any, E = any> extends TableColumnBase<T, E> {

    constructor(init: DataTableColumnSpecification<T, E>) {
        super(FieldTypesEnum.Number, init);
    }

}

export class TableMoneyColumn<T = any, E = any> extends TableColumnBase<T, E> {

    constructor(init: DataTableColumnSpecification<T, E>) {
        super(FieldTypesEnum.Money, init);
    }

    currencyCodeField?: string;
}


export interface DropDownDataSource<T = any> {
    displayFieldName: string;
    valueFieldName: string;
    enabledFieldName?: string | null;
    items$: Observable<T[]>
}

export enum FieldTypesEnum {
    Text = "text",
    Time = "time",
    Date = "date",
    Tel = "tel",
    Number = "number",
    Money = "money",
    Email = "email",
    Boolean = "checkbox",
    DropDown = "dropdown",
    Enum = "enum",
    CopyPasteAction = "CopyPasteAction",
    SelectAction = "SelectAction",
    WithTemplate = "WithTemplate"
}

export enum AggregatesTypesEnum {
    Sum = "Sum",
    Avg = "Average",
    Count = "Count",
    Min = "Min",
    Max = "Max",
    Custom = "Custom",
}

export enum AggregatesOperatorsEnum {
    Source = "Source",
    ValueCallBack = "ValueCallBack",
    Ignore = "Ignore",
}
