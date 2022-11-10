import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BaseService } from './BaseService';
import { ControllerName } from '../constants/ControllerName';
import { MyConfig } from '../shared/MyConfig';

@Injectable({
  providedIn: 'root',
})
export class NewsService extends BaseService {
  constructor(httpClient: HttpClient, router: Router) {
    super(httpClient, router, ControllerName.News);
  }

  addNew(data: FormData) {
    return this.httpClient.post(MyConfig.address_server + 'api/News/Add', data);
  }

  editNew(data: FormData) {
    return this.httpClient.put(
      MyConfig.address_server + 'api/News/Edit/' + data.get('id'),
      data
    );
  }
}
