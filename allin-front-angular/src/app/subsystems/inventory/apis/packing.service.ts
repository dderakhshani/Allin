import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../core/services/base.http.service';
import { CreatePackingCommnad } from '../models/commands/create-packing-command';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class PackingService {

    private readonly controllerPath = "inventory/packing";

    constructor(private baseHttpService: BaseHttpService) { }

    create(model: CreatePackingCommnad): Observable<any> {
        return this.baseHttpService.postJsonData({
            controller: this.controllerPath, action: 'create'
        }, model);
    }
}
