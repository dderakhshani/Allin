import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../core/services/base.http.service';
import { Observable } from 'rxjs';
import { PersonModel } from '../models/queries/person-model';
import { EditPersonCommand } from '../models/commands/edit-person-command';
import { CreatePersonCommand } from '../models/commands/create-Person-command';
import { PagedList } from '../../../core/components/png-table/models/paged-list';

@Injectable({
    providedIn: 'root'
})
export class PersonService {

    private readonly controllerPath = "person";

    constructor(private baseHttpService: BaseHttpService) { }

    create(model: CreatePersonCommand): Observable<any> {
        return this.baseHttpService.postJsonData({
            controller: this.controllerPath, action: 'create'
        }, model);
    }

    edit(model: EditPersonCommand): Observable<void> {
        return this.baseHttpService.putJsonData({
            controller: this.controllerPath,
            action: 'edit'
        }, model);
    }

    delete(id: number): Observable<boolean> {
        return this.baseHttpService.deleteData(
            {
                controller: this.controllerPath,
                action: 'delete',
                routeParameters: [id]
            });
    }

    getAll(): Observable<PagedList<PersonModel[]>> {
        return this.baseHttpService.getData({
            controller: this.controllerPath,
            action: 'get-all',
            routeParameters: []
        });
    }

    getById(id: number): Observable<PersonModel> {
        return this.baseHttpService.getData({
            controller: this.controllerPath,
            action: 'get-by-id',
            routeParameters: [id]
        });
    }



}
