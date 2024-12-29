import { Validators } from '@angular/forms';
import { Observable } from 'rxjs';


type DataTableColumnSpecification<T, E = any> = Partial<Omit<TableColumnBase<T>, 'fieldType' | 'fieldName' | 'valueFieldName' | 'groupingField'>> &
    Pick<TableColumnBase<T>, 'title'> &
{
    rootFieldName: Extract<keyof T, string>,
    nestedFieldName?: Extract<keyof E, string>,
    rootValueFieldName?: Extract<keyof T, string>,
    nestedValueFieldName?: Extract<keyof E, string>,
    rootTextFieldName?: Extract<keyof T, string>,
    nestedTextFieldName?: Extract<keyof E, string>,
    rootGroupingFieldName?: Extract<keyof T, string>,
    nestedGroupingFieldName?: Extract<keyof E, string>,
    requiredFields?: { rootFieldName: Extract<keyof T, string>, nestedFieldName?: Extract<keyof E, string> }[]
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
        this.fieldName = init.rootFieldName;
        if (init.nestedFieldName) {
            this.fieldName += `.${init.nestedFieldName}`
        }

        if (init.filterOptions)
            this.filterOptions = init.filterOptions;
        else
            this.filterOptions = new TableColumnFilterOptions();

        this.requiredFieldNames = [];
        for (let requiredField of init.requiredFields ?? []) {
            let field = String(requiredField.rootFieldName);
            if (requiredField.nestedFieldName) {
                field += `.${requiredField.nestedFieldName}`
            }
            this.requiredFieldNames.push(field);
        }

        if (init.rootGroupingFieldName) {
            this.groupingField = init.rootGroupingFieldName;
            if (init.nestedGroupingFieldName) {
                this.groupingField += `.${init.nestedGroupingFieldName}`;
            }
        } else {
            this.groupingField = this.fieldName;
        }

        if (!this.orderingFields)
            this.orderingFields = [this.fieldName];

        this.isDatabaseColumn = (this._fieldType != FieldTypesEnum.WithTemplate || (this.fieldName != undefined && this.fieldName != null && this.fieldName != ''));


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

    filterOptions: TableColumnFilterOptions;

    templateRefId?: string;

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

        if (!init.filterOptions) {
            init.filterOptions = new TableColumnCheckBoxFilterOptions();
        }
    }

    displayStyle: BooleanColumnDisplayEnum = BooleanColumnDisplayEnum.Checkbox;

}

export class TableDropDownColumn<T = any, E = any> extends TableColumnBase<T, E> {

    constructor(init: DataTableColumnSpecification<T, E> & { itemsSource: TableColumnDropDownOptions }) {
        super(FieldTypesEnum.DropDown, init);

        if (init.rootTextFieldName) {
            this.itemsSource.displayFieldName = init.rootTextFieldName;
            if (init.nestedTextFieldName) {
                this.itemsSource.displayFieldName += `.${init.nestedTextFieldName}`;
            }
        } else {
            this.itemsSource.displayFieldName = this.fieldName;
        }


        if (init.rootValueFieldName) {
            this.itemsSource.valueFieldName = init.rootValueFieldName;
            if (init.nestedValueFieldName) {
                this.itemsSource.valueFieldName += `.${init.nestedValueFieldName}`;
            }
        } else {
            this.itemsSource.valueFieldName = this.fieldName;
        }

        // if (this.fieldType === FieldTypesEnum.Enum && init.multiple === undefined)
        //     this.multiple = true;

        if (!init.filterOptions) {
            init.filterOptions = new TableColumnDropDownFilterOptions(init.itemsSource.items);
        }
    }

    public itemsSource!: TableColumnDropDownOptions;
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

export class TableColumnFilterOptions<T = any> {
    filterable: boolean | 'rowOnly' | 'cardOnly' = true;
    globalFilterable: boolean | 'rowOnly' | 'cardOnly' = true;
    filterControl: FilterControlEnum = FilterControlEnum.TextField;
}

//This Option is not only for drop-down columns, can be applied on any columns
export class TableColumnDropDownFilterOptions<T = any> extends TableColumnFilterOptions<T> {
    multipleItemsSelect: boolean = true;
    items: Observable<T[]> | T[];

    constructor(items: Observable<T[]> | T[]) {
        super();
        this.filterControl = FilterControlEnum.DropDown;
        this.items = items;
    }
}

//Only for numeric columns
export class TableColumnNumberFilterOptions<T = any> extends TableColumnFilterOptions<T> {
    minValue?: number;
    maxValue?: number;

    constructor() {
        super();
        this.filterControl = FilterControlEnum.FromTo;//Default Control
    }
}

export class TableColumnCheckBoxFilterOptions<T = any> extends TableColumnFilterOptions<T> {
    constructor() {
        super();
        this.filterControl = FilterControlEnum.checkBox;
    }
}

export interface TableColumnDropDownOptions<T = any> {
    displayFieldName: string;
    valueFieldName: string;
    enabledFieldName?: string | null;
    items: Observable<T[]> | T[];

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
    Enum = "enum",//TODO: reserved for future
    WithTemplate = "WithTemplate"
}
export enum BooleanColumnDisplayEnum {
    CheckCloseColorfull = 'check-close-color',
    CheckCloseNoColor = 'check-close',
    OnlyCheckCloseColorFull = 'only-check-color',
    OnlyCheckCloseNoColor = 'only-check',
    Checkbox = 'checkbox',
}

export enum FilterControlEnum {
    TextField = 'text-field',
    DropDown = 'drop-down',
    FromTo = 'from-to',
    Slider = 'slider',
    checkBox = 'checkBox'
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
