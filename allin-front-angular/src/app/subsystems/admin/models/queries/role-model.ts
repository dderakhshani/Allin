import { TreeNode } from "primeng/api";
import { PermissiontModel } from "./permission-model";

export interface RoleModel {
    id: number;
    title: string;
    uniqueName: string;
    parentId?: number;
    description: string;
    permissions: TreeNode<PermissiontModel>[];


}