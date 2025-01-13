
export interface EditDepartmentCommand {
    id?: number;
    parentId?: number;
    code?: string;
    title?: string;
    branchId?: number;
    positionIds?: number[];
}