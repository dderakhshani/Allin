import { ExtendedFieldValueModel } from "../../../shared/models/extended-field-value-model";
import { CreatePersonCommand } from "./create-Person-command";

export interface CreateEmployeeCommand {
    employeeCode?: string;
    positionId?: number;
    departmentId?: number;

    person?: CreatePersonCommand;
    personId?: number;

    extendedFieldValues?: ExtendedFieldValueModel[];
}