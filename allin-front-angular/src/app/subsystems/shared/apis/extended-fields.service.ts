import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ExtendedFieldModel } from '../models/extended-fields-model';

@Injectable({
  providedIn: 'root'
})
export class ExtendedFieldsService {

  private urlGetExtendedFields = `${environment.baseUrl}/api/extended-field`;

  constructor(private HttpClient: HttpClient) { }

  // getExtendedFields(tableName: string) {
  //   let params = new HttpParams()
  //     .set('tablName', tableName);

  //   return this.HttpClient.get<ExtendedFieldModel[]>(this.urlGetExtendedFields, { params: params });
  // }

  getExtendedFields(tableName: string) {
    return this.HttpClient.get<ExtendedFieldModel[]>(`${this.urlGetExtendedFields}/${tableName}`);
  }

}
