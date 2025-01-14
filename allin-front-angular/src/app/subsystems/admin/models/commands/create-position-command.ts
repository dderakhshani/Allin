
export interface CreatePositionCommand {
    parentId?: number;
    code?: string;
    title?: string;
    branchId?: number;
    positionIds?: number[];
}