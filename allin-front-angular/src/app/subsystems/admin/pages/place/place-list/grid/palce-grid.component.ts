import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PlacetModel } from '../../../../models/queries/place-model';
import { TreeNode } from 'primeng/api';
import { BasicModule } from '../../../../../../core/basic.module';
import { TreeTableModule } from 'primeng/treetable';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
    selector: 'app-palce-grid',
    standalone: true,
    imports: [BasicModule,
        TreeTableModule],
    templateUrl: './palce-grid.component.html',
    styleUrl: './palce-grid.component.scss'
})
export class PalceGridComponent {

    @Input()
    data?: TreeNode<PlacetModel>[];

    @Output()
    onAddChildClick = new EventEmitter<PlacetModel>();
    @Output()
    onEditClick = new EventEmitter<PlacetModel>();
    @Output()
    onDeleteClick = new EventEmitter<PlacetModel>();

    ref: DynamicDialogRef | undefined;

    constructor(public dialogService: DialogService,
    ) { }

    ngOnInit() {
    }

    addChildClick(item: PlacetModel) {
        this.onAddChildClick.emit(item);
    }

    editClick(item: PlacetModel) {
        this.onEditClick.emit(item);
    }

    deleteClick(item: PlacetModel) {
        this.onDeleteClick.emit(item);
    }

}
