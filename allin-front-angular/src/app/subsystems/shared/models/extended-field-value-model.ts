import { ExtendedFieldModel } from "./extended-fields-model";

export interface ExtendedFieldValueModel extends ExtendedFieldModel {
    tableExtendedFieldId: number;
    value: any;
    valueFieldItemId: number;
}