export interface PositionModel {
    id: number;
    parentId?: number;
    hierarchy: string;
    code: string;
    title: string;
    branchId: number;
    children: PositionModel[];

}