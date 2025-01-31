export interface ExtendedFieldModel {
    id: number;
    parentId?: number;
    tableName: string;
    fieldName: string;
    uniqueName: string;
    description: string;
    fieldType: number,
    uiControl: number,
    orderIndex: number,
    // items:[]

}
