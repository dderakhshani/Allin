import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TreeNode } from 'primeng/api';
import { OrganizationChartModule } from 'primeng/organizationchart';
import { BasicModule } from '../../../../../../core/basic.module';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { PositionModel } from '../../../../models/queries/position-model';
import { PositionService } from '../../../../apis/position.service';
@Component({
    selector: 'app-position-chart',
    standalone: true,
    imports: [BasicModule,
        OrganizationChartModule
    ],
    templateUrl: './position-chart.component.html',
    styleUrl: './position-chart.component.scss'
})
export class PositionChartComponent {

    @Input()
    data?: TreeNode<PositionModel>[];
    @Output()
    onAddChildClick = new EventEmitter<PositionModel>();
    @Output()
    onEditClick = new EventEmitter<PositionModel>();
    @Output()
    onDeleteClick = new EventEmitter<PositionModel>();

    ref: DynamicDialogRef | undefined;

    constructor(public dialogService: DialogService,
    ) { }

    addChildClick(node: TreeNode<PositionModel>) {
        this.onAddChildClick.emit(node.data);
    }

    editClick(node: TreeNode<PositionModel>) {
        this.onEditClick.emit(node.data);
    }

    deleteClick(node: TreeNode<PositionModel>) {

        if (node.data) {
            let item: PositionModel = { ...node.data };
            this.onDeleteClick.emit(item);
        }
    }
}