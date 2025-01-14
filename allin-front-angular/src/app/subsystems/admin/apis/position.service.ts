import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../core/services/base.http.service';
import { Observable } from 'rxjs';
import { TreeNode } from 'primeng/api';
import { CreatePositionCommand } from '../models/commands/create-position-command';
import { EditPositionCommand } from '../models/commands/edit-position-command';
import { PositionModel } from '../models/queries/position-model';

@Injectable({
  providedIn: 'root'
})
export class PositionService {

  private readonly controllerPath = "position";

  constructor(private baseHttpService: BaseHttpService) { }

  create(model: CreatePositionCommand): Observable<any> {
    return this.baseHttpService.postJsonData({
      controller: this.controllerPath, action: 'create'
    }, model);
  }

  delete(id: number): Observable<boolean> {
    return this.baseHttpService.deleteData(
      {
        controller: this.controllerPath,
        action: '',
        routeParameters: [id]
      });
  }

  edit(model: EditPositionCommand): Observable<void> {
    return this.baseHttpService.putJsonData({
      controller: this.controllerPath,
      action: 'edit'
    }, model);
  }

  getAllTree(): Observable<TreeNode<PositionModel>[]> {
    return this.baseHttpService.getData({
      controller: this.controllerPath,
      action: 'get-department-tree',
      routeParameters: []
    });
  }


}
