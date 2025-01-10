export interface DepartmentModel {
    id: number;
    parentId?: number;
    hierarchy: string;
    code: string;
    title: string;
    branchId: number;
    children: DepartmentModel[];

}