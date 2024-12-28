import { of } from "rxjs";
import { DropDownDataSource } from "./table-column-model";

export interface TextValue<T = number> {
    text: string;
    value: T;
    extraProperties?: any;
}

export const textValuesToDropdownItems = <T>(textValues: TextValue<T>[]): DropDownDataSource<{ text: string, value: T }> => {
    return { displayFieldName: 'text', valueFieldName: 'value', items$: of(textValues) };
}