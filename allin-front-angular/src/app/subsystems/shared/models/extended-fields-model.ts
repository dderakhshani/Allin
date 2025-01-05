import { ExtendedFieldTypeEnum } from "./enums/extended-field-type-enum";
import { ExtendedFieldUIControl } from "./enums/extended-field-ui-control-enum";

export interface ExtendedFieldModel {
    title: string;
    uniqueName: string;
    orderIndex: string;
    description: string;
    fieldType: ExtendedFieldTypeEnum;
    uiControl: ExtendedFieldUIControl;
}