
export class QueryGroup {
    level = 0;
    parent!: QueryGroup;
    expanded = true;
    totalCounts = 0;
    [key: string]: any;
    get visible(): boolean {
        return !this.parent || (this.parent.visible && this.parent.expanded);
    }
}
