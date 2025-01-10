import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../core/services/base.http.service';
import { Observable } from 'rxjs';
import { DepartmentModel } from '../models/queries/department-model';
import { PagedList } from '../../../core/components/png-table/models/paged-list';
import { TreeNode } from 'primeng/api';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  private readonly controllerPath = "department";

  constructor(private baseHttpService: BaseHttpService) { }

  getAllTree(): Observable<TreeNode<DepartmentModel>[]> {
    return this.baseHttpService.getData({
      controller: this.controllerPath,
      action: 'get-department-tree',
      routeParameters: []
    });
  }

}
