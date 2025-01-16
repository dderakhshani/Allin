
export interface EditRoleCommand {
    id?: number;
    title?: string;
    uniqueName?: string;
    description?: string;
    departmentId?: number;
    permissionIds?: number[];
}