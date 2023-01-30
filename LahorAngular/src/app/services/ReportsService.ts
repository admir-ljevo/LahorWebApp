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
export class ReportsService {
  constructor(private httpClient: HttpClient, private router: Router) {}

  generateServicesReport(search: ReportSearchObject) {
    if (search.reportType == ReportType.PDF) {
      return this.httpClient.get<any>(
        MyConfig.address_server +
          ControllerName.Reports +
          '/services?reportType=' +
          search.reportType +
          '&DateFrom=' +
          search.dateFrom +
          '&DateTo=' +
          search.dateTo,
        MyConfig.http_options_response_blob
      );
    } else {
      return this.httpClient.get<any>(
        MyConfig.address_server +
          ControllerName.Reports +
          '/services?reportType=' +
          search.reportType +
          '&DateFrom=' +
          search.dateFrom +
          '&DateTo=' +
          search.dateTo
      );
    }
  }
  generateEmployeesReport(search: ReportSearchObject) {
    if (search.reportType == ReportType.PDF) {
      return this.httpClient.get<any>(
        MyConfig.address_server +
          ControllerName.Reports +
          '/employees?reportType=' +
          search.reportType +
          '&DateFrom=' +
          search.dateFrom +
          '&DateTo=' +
          search.dateTo,
        MyConfig.http_options_response_blob
      );
    } else {
      return this.httpClient.get<any>(
        MyConfig.address_server +
          ControllerName.Reports +
          '/employees?reportType=' +
          search.reportType +
          '&DateFrom=' +
          search.dateFrom +
          '&DateTo=' +
          search.dateTo
      );
    }
  }
  generateClientsReport(search: ReportSearchObject) {
    if (search.reportType == ReportType.PDF) {
      return this.httpClient.get<any>(
        MyConfig.address_server +
          ControllerName.Reports +
          '/clients?reportType=' +
          search.reportType +
          '&DateFrom=' +
          search.dateFrom +
          '&DateTo=' +
          search.dateTo,
        MyConfig.http_options_response_blob
      );
    } else {
      return this.httpClient.get<any>(
        MyConfig.address_server +
          ControllerName.Reports +
          '/clients?reportType=' +
          search.reportType +
          '&DateFrom=' +
          search.dateFrom +
          '&DateTo=' +
          search.dateTo
      );
    }
  }
}
