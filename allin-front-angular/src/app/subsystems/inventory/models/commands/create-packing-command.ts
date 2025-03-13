export interface CreatePackingCommnad {

    levelCode: number;
    title: string;
    conversionFactor: number;
    measureUnitBaseId: number;
    arrangements?: CreateArrangementCommnad[];

}

export interface CreateArrangementCommnad {

    packingId: number;
    conversionFactor: number;
    containerPackingId: number;

}