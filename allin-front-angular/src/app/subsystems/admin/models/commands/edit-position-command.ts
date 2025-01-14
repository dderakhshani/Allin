
export interface EditPositionCommand {
    id?: number;
    parentId?: number;
    code?: string;
    title?: string;
    branchId?: number;
    positionIds?: number[];
}