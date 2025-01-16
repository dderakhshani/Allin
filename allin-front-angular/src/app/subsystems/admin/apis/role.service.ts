import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../core/services/base.http.service';
import { TreeNode } from 'primeng/api';
import { Observable } from 'rxjs';
import { PermissiontModel } from '../models/queries/permission-model';
import { CreateRoleCommand } from '../models/commands/create-role-command';
import { RoleModel } from '../models/queries/role-model';
import { EditRoleCommand } from '../models/commands/edit-role-command';

@Injectable({
    providedIn: 'root'
})
export class RoleService {

    private readonly controllerPath = "role-permission";

    constructor(private baseHttpService: BaseHttpService) { }

    create(model: CreateRoleCommand): Observable<any> {
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

    edit(model: EditRoleCommand): Observable<void> {
        return this.baseHttpService.putJsonData({
            controller: this.controllerPath,
            action: 'edit'
        }, model);
    }


    // getAll(): Observable<RoleModel[]> {
    //     return this.baseHttpService.getData({
    //         controller: this.controllerPath,
    //         action: 'get-all',
    //         routeParameters: []
    //     });
    // }

    getAllTree(): Observable<TreeNode<PermissiontModel>[]> {
        return this.baseHttpService.getData({
            controller: this.controllerPath,
            action: 'get-permissions-tree',
            routeParameters: []
        });
    }

    getPermissionsTreeByRoleId(id: number): Observable<PermissiontModel[]> {
        return this.baseHttpService.getData(
            {
                controller: this.controllerPath,
                action: 'get-permissions-tree-by-role-id',
                routeParameters: [id]
            });
    }
}
