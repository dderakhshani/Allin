import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../core/services/base.http.service';
import { Observable } from 'rxjs';
import { ExtendedFieldModel } from '../models/queries/extendedfield-model';
import { PagedList } from '../../../core/components/png-table/models/paged-list';
import { TreeNode } from 'primeng/api';

@Injectable({
    providedIn: 'root'
})
export class ExtendedfieldNewService {

    private readonly controllerPath = "extended-field";

    constructor(private baseHttpService: BaseHttpService) { }

    getExtendedFieldTreeByTableName(tableNameTemp: string): Observable<PagedList<TreeNode<ExtendedFieldModel>[]>> {


        return this.baseHttpService.getData(
            {
                controller: this.controllerPath,
                action: 'get-all',
                routeParameters: [tableNameTemp]
            });
    }
}
