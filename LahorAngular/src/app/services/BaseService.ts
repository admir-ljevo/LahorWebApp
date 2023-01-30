import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { BaseSearchObject } from '../searchObject/BaseSearchObject';
import { MyConfig } from '../shared/MyConfig';

export class BaseService {
  news: any;
  controllerName: string;
  config = new MyConfig();
  constructor(
    protected httpClient: HttpClient,
    protected router: Router,
    ControllerName: string
  ) {
    this.controllerName = ControllerName;
  }
  getAll(): Observable<any[]> {
    return this.httpClient.get<any>(
      MyConfig.address_server + this.controllerName + '/',
      this.config.getHttpHeaderOption()
    );
  }

  getForPagination(
    search: BaseSearchObject,
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
        '?SearchFilter=' +
        search.searchFilter,
      this.config.getHttpHeaderOption()
    );
  }

  getById(id: Number): Observable<any> {
    return this.httpClient.get<any>(
      MyConfig.address_server + this.controllerName + '/' + id,
      this.config.getHttpHeaderOption()
    );
  }

  post(data: any) {
    return this.httpClient.post<any>(
      MyConfig.address_server + this.controllerName + '/',
      data,
      this.config.getHttpHeaderOption()
    );
  }

  delete(data: any) {
    return this.httpClient.delete<any>(
      MyConfig.address_server + this.controllerName + '/' + data.id,
      this.config.getHttpHeaderOption()
    );
  }

  update(data: any) {
    return this.httpClient.put<any>(
      MyConfig.address_server + this.controllerName + '/' + data.id,
      data,
      this.config.getHttpHeaderOption()
    );
  }
}
