
export class TableConfigOptions {

    public constructor(init?: Partial<TableConfigOptions>) {
        if (init)
            Object.assign(this, init);
    }
    toolbarOptions: ToolBarConfig = new ToolBarConfig();

    rowsPerPageOptions = [10, 50, 100, 200];
    // cardConfig?: CardConfig;
    showTotals?: boolean = true;
    grouping: boolean | 'rowOnly' | 'cardOnly' = true;
    exportable: boolean | 'rowOnly' | 'cardOnly' = true;
    selectable: boolean = true;
    stickySelectable: boolean = false;
    defaultDateFormat: string = 'd MMM y';
    paging: boolean | 'rowOnly' | 'cardOnly' = true;
    serverPaging: boolean = true;
    filterable: boolean | 'rowOnly' | 'cardOnly' = true;
    serverFiltering: boolean = true;
    sortable: boolean | 'rowOnly' | 'cardOnly' = true;
    serverSorting: boolean = true;
    rowEditMode: 'never' | 'always' | 'onDoubleClick' | 'bySelection' = 'never';

    saveUserSettingsInCache: boolean = true

}

export class ToolBarConfig {
    constructor(init?: Partial<ToolBarConfig>) {
        if (init)
            Object.assign(this, init);
    }
    showToolbar: boolean = true;
    settings: boolean | 'rowOnly' | 'cardOnly' = true;
    displayMode: boolean | 'rowOnly' | 'cardOnly' = true;
    refresh: boolean | 'rowOnly' | 'cardOnly' = true;
    export: boolean | 'rowOnly' | 'cardOnly' = true;
    sort: boolean | 'rowOnly' | 'cardOnly' = true;
    group: boolean | 'rowOnly' | 'cardOnly' = true;
}
export const NoToolbarCTableConfig = new TableConfigOptions({ toolbarOptions: new ToolBarConfig({ showToolbar: false }) });
