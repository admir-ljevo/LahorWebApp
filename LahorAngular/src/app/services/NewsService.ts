import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BaseService } from './BaseService';
import { ControllerName } from '../constants/ControllerName';
import { MyConfig } from '../shared/MyConfig';
import { NewsSearchObject } from '../searchObject/NewsSearchObject';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NewsService extends BaseService {
  constructor(httpClient: HttpClient, router: Router) {
    super(httpClient, router, ControllerName.News);
  }

  addNew(data: FormData) {
    return this.httpClient.post(
      MyConfig.address_server + 'News/Add',
      data,
      this.config.getHttpHeaderOption()
    );
  }

  editNew(data: FormData) {
    return this.httpClient.put(
      MyConfig.address_server + 'News/Edit/' + data.get('id'),
      data,
      this.config.getHttpHeaderOption()
    );
  }

  getLastFiveNews(isPublic: boolean) {
    return this.httpClient.get(
      MyConfig.address_server + 'News/GetLastFiveNews?isPublic=' + isPublic,
      this.config.getHttpHeaderOption()
    );
  }
}
