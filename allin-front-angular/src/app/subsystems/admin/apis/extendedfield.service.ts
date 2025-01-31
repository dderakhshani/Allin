import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../core/services/base.http.service';
import { Observable } from 'rxjs';
import { ExtendedFieldModel } from '../models/queries/extendedfield-model';

@Injectable({
    providedIn: 'root'
})
export class ExtendedfieldNewService {

    private readonly controllerPath = "extended-field";

    constructor(private baseHttpService: BaseHttpService) { }

    getExtendedFieldByTableName(tableName: string): Observable<ExtendedFieldModel[]> {
        return this.baseHttpService.getData(
            {
                controller: this.controllerPath,
                action: 'get-all',
                routeParameters: [tableName]
            });
    }
}
