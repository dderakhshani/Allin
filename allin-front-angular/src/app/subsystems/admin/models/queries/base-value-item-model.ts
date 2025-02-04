export interface BaseValueItemModel {
    id: number;
    parentId?: number;
    hierarchy: string;
    title: string;
    value: number;
    uniqueName: string;
    description: string;
    baseValueId: number;
    order: number;
    baseValueUniqueName: string;
    children: BaseValueItemModel[];
}
