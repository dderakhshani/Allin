import { ExtendedFieldValueModel } from "../../../shared/models/extended-field-value-model";

export interface CreateRoleCommand {
    title?: string;
    uniqueName?: string;
    description?: string;
    departmentId?: number;
    permissionIds?: number[];
}