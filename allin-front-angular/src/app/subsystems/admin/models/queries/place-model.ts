export interface PlacetModel {
    id: number;
    parentId?: number;
    hierarchy: string;
    code: string;
    placeTitle: string;
    placeBaseId: number;
    children: PlacetModel[];

}