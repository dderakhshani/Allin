export interface PermissiontModel {
    id: number;
    parentId?: number;
    hierarchy: string;
    subSystem: string;
    title: string;
    uniqueName: string;
    children: PermissiontModel[];

}