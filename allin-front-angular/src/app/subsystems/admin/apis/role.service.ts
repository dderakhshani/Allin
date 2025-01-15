import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../core/services/base.http.service';
import { TreeNode } from 'primeng/api';
import { Observable } from 'rxjs';
import { PermissiontModel } from '../models/queries/permission-model';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  private readonly controllerPath = "role";

  constructor(private baseHttpService: BaseHttpService) { }

  // create(model: CreateDepartmentCommand): Observable<any> {
  //   return this.baseHttpService.postJsonData({
  //     controller: this.controllerPath, action: 'create'
  //   }, model);
  // }

  // delete(id: number): Observable<boolean> {
  //   return this.baseHttpService.deleteData(
  //     {
  //       controller: this.controllerPath,
  //       action: '',
  //       routeParameters: [id]
  //     });
  // }

  // edit(model: EditDepartmentCommand): Observable<void> {
  //   return this.baseHttpService.putJsonData({
  //     controller: this.controllerPath,
  //     action: 'edit'
  //   }, model);
  // }


  getAllTree(): Observable<TreeNode<PermissiontModel>[]> {
    return this.baseHttpService.getData({
      controller: this.controllerPath,
      action: 'get-permissions-tree',
      routeParameters: []
    });
  }
}
