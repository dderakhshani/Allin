
export interface CreateRoleCommand {
    title?: string;
    uniqueName?: string;
    description?: string;
    departmentId?: number;
    permissionIds?: number[];
}