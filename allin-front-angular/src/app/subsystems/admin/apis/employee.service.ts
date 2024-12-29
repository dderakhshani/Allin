import { Injectable } from '@angular/core';
import { BaseHttpService } from '../../../core/services/base.http.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private baseHttpService: BaseHttpService) { }
}
