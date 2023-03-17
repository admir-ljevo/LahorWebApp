import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BaseService } from './BaseService';
import { ControllerName } from '../constants/ControllerName';
import { Observable } from 'rxjs';
import { MyConfig } from '../shared/MyConfig';
import { CountriesCitiesSearchObject } from '../searchObject/CountriesCititesSearchObject';

@Injectable({
  providedIn: 'root',
})
export class CitiesService extends BaseService {
  constructor(httpClient: HttpClient, router: Router) {
    super(httpClient, router, ControllerName.Cities);
  }

  override getForPagination(
    search: CountriesCitiesSearchObject,
    pageSize: any,
    pageNumber: any
  ): Observable<any[]> {
    console.log(search);
    return this.httpClient.get<any>(
      MyConfig.address_server +
        this.controllerName +
        '/' +
        pageNumber +
        '/' +
        pageSize +
        '?CountryId=' +
        search.countryId +
        '&' +
        'SearchFilter=' +
        search.searchFilter,
      this.config.getHttpHeaderOption()
    );
  }
}
