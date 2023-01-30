import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BaseService } from './BaseService';
import { ControllerName } from '../constants/ControllerName';
import { MyConfig } from '../shared/MyConfig';

@Injectable({
  providedIn: 'root',
})
export class DashboardService extends BaseService {
  constructor(httpClient: HttpClient, router: Router) {
    super(httpClient, router, ControllerName.Employees);
  }

  getStatistics() {
    return this.httpClient.get(
      MyConfig.address_server + 'Dashboard/GetStatistics',
      this.config.getHttpHeaderOption()
    );
  }
}
