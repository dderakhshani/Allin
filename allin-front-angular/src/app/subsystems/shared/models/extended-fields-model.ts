import { ExtendedFieldTypeEnum } from "./enums/extended-field-type-enum";
import { ExtendedFieldUIControlEnum } from "./enums/extended-field-ui-control-enum";

export interface ExtendedFieldModel {
    id: number;
    fieldName: string;
    description: string;
    uniqueName: string;
    orderIndex: number;
    Items: [];
    fieldType: number;
    uiControl: number;
}