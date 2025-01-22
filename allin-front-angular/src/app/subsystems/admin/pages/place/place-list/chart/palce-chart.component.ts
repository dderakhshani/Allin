import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PlacetModel } from '../../../../models/queries/place-model';
import { TreeNode } from 'primeng/api';
import { BasicModule } from '../../../../../../core/basic.module';
import { OrganizationChartModule } from 'primeng/organizationchart';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
    selector: 'app-palce-chart',
    standalone: true,
    imports: [BasicModule,
        OrganizationChartModule],
    templateUrl: './palce-chart.component.html',
    styleUrl: './palce-chart.component.scss'
})
export class PalceChartComponent {

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

    addChildClick(node: TreeNode<PlacetModel>) {
        this.onAddChildClick.emit(node.data);
    }

    editClick(node: TreeNode<PlacetModel>) {
        this.onEditClick.emit(node.data);
    }

    deleteClick(node: TreeNode<PlacetModel>) {

        if (node.data) {
            let item: PlacetModel = { ...node.data };
            this.onDeleteClick.emit(item);
        }
    }

}
