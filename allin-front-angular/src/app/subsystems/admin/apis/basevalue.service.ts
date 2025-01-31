import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../core/services/base.http.service';
import { Observable } from 'rxjs';
import { CreateBaseValueCommand } from '../models/commands/create-basevalue-command';

@Injectable({
    providedIn: 'root'
})
export class BasevalueService {

    private readonly controllerPath = "base-value";

    constructor(private baseHttpService: BaseHttpService) { }

    create(model: CreateBaseValueCommand): Observable<any> {
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
    deleteItems(id: number): Observable<boolean> {
        return this.baseHttpService.deleteData(
            {
                controller: this.controllerPath,
                action: 'delete-item',
                routeParameters: [id]
            });
    }
}
