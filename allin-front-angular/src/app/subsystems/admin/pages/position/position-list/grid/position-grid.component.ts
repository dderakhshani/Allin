import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TreeNode } from 'primeng/api';
import { TreeTableModule } from 'primeng/treetable';
import { BasicModule } from '../../../../../../core/basic.module';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { PositionModel } from '../../../../models/queries/position-model';
import { PositionService } from '../../../../apis/position.service';

@Component({
    selector: 'app-position-grid',
    standalone: true,
    imports: [
        BasicModule,
        TreeTableModule],
    templateUrl: './position-grid.component.html',
    styleUrl: './position-grid.component.scss'
})
export class PositionGridComponent {

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

    ngOnInit() {
    }

    addChildClick(item: PositionModel) {
        this.onAddChildClick.emit(item);
    }

    editClick(item: PositionModel) {
        this.onEditClick.emit(item);
    }

    deleteClick(item: PositionModel) {
        this.onDeleteClick.emit(item);
    }

}
