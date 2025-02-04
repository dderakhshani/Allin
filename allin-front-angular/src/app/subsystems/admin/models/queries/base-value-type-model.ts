import { TreeNode } from "primeng/api";
import { BaseValueItemModel } from "./base-value-item-model";

export interface BaseValueTypeModel {
    id: number;
    title: string;
    uniqueName: string;
    description: string;
    items: TreeNode<BaseValueItemModel>[];
}