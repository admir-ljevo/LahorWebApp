import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BaseService } from './BaseService';
import { ControllerName } from '../constants/ControllerName';
import { MyConfig } from '../shared/MyConfig';
import { ReportSearchObject } from '../searchObject/ReportSearchObject';
import { ReportType } from '../core/enumerations/reportType';

@Injectable({
  providedIn: 'root',
})
export class EnumService {
  constructor(private httpClient: HttpClient, private router: Router) {}

  genders() {
    return this.httpClient.get<any>(
      MyConfig.address_server + ControllerName.Enum + '/genders'
    );
  }

  drivingLicenses() {
    return this.httpClient.get<any>(
      MyConfig.address_server + ControllerName.Enum + '/drivingLicenses'
    );
  }

  positions() {
    return this.httpClient.get<any>(
      MyConfig.address_server + ControllerName.Enum + '/positions'
    );
  }

  marriageStatuses() {
    return this.httpClient.get<any>(
      MyConfig.address_server + ControllerName.Enum + '/marriageStatuses'
    );
  }
}
