
export interface CreateDepartmentCommand {
    parentId?: number;
    code?: string;
    title?: string;
    branchId?: number;
    positionIds?: number[];
}