import { ExtendedFieldValueModel } from "../../../shared/models/extended-field-value-model";
import { CreatePersonCommand } from "./create-Person-command";

export interface CreateEmployeeCommand {
    personId?: number;
    departmentPositionId?: number;
    employeeCode?: string;
    employmentDate?: Date;
    contractTypeBaseId?: number;
    floating?: boolean;
    extendedFieldValues?: ExtendedFieldValueModel[];
}