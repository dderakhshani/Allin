import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../core/services/base.http.service';
import { CreateEmployeeCommand } from '../models/commands/create-employee-command';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EmployeeService {

    private readonly controllerPath = "admin/employee";

    constructor(private baseHttpService: BaseHttpService) { }

    create(model: CreateEmployeeCommand): Observable<any> {
        return this.baseHttpService.postJsonData({
            controller: this.controllerPath, action: 'create'
        }, model);
    }

}
