
export interface CreateBaseValueCommand {
    title?: string;
    uniqueName?: string;
    description?: string;
    items?: CreateBaseValueItemCommand[];
}

export interface CreateBaseValueItemCommand {
    title?: string;
    description?: string;
    baseValueId?: number;
    parentId?: number;
    order?: number;
    value?: number;
}