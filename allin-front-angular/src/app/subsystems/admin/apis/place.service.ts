import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../core/services/base.http.service';
import { CreatePlaceCommand } from '../models/commands/create-place-command';
import { Observable } from 'rxjs';
import { PlacetModel } from '../models/queries/place-model';
import { TreeNode } from 'primeng/api';
import { EditPlaceCommand } from '../models/commands/edit-place-command';

@Injectable({
    providedIn: 'root'
})
export class PlaceService {

    private readonly controllerPath = "place";

    constructor(private baseHttpService: BaseHttpService) { }

    create(model: CreatePlaceCommand): Observable<any> {
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

    edit(model: EditPlaceCommand): Observable<void> {
        return this.baseHttpService.putJsonData({
            controller: this.controllerPath,
            action: 'edit'
        }, model);
    }


    getAllTree(): Observable<TreeNode<PlacetModel>[]> {
        return this.baseHttpService.getData({
            controller: this.controllerPath,
            action: 'get-place-tree',
            routeParameters: []
        });
    }
}
