import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BaseService } from './BaseService';
import { ControllerName } from '../constants/ControllerName';
import { MyConfig } from '../shared/MyConfig';
import { Observable } from 'rxjs';
import { ServicesSearchObject } from '../searchObject/ServicesSearchObject';

@Injectable({
  providedIn: 'root',
})
export class ServicesService extends BaseService {
  constructor(httpClient: HttpClient, router: Router) {
    super(httpClient, router, ControllerName.Services);
  }

  override getForPagination(
    search: ServicesSearchObject,
    pageSize: any,
    pageNumber: any
  ): Observable<any[]> {
    return this.httpClient.get<any>(
      MyConfig.address_server +
        this.controllerName +
        '/' +
        pageNumber +
        '/' +
        pageSize +
        '?TypeOfServiceId=' +
        search.typeOfServiceId +
        '&' +
        'SearchFilter=' +
        search.searchFilter,
      this.config.getHttpHeaderOption()
    );
  }
}
