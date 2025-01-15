export interface RoleModel {
    id: number;
    title: string;
    uniqueName: string;
    parentId?: number;
    description: string;
    permissions: [];


}