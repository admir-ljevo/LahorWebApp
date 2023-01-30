import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BaseService } from './BaseService';
import { ControllerName } from '../constants/ControllerName';
import { MyConfig } from '../shared/MyConfig';

@Injectable({
  providedIn: 'root',
})
export class EmployeesService extends BaseService {
  constructor(httpClient: HttpClient, router: Router) {
    super(httpClient, router, ControllerName.Employees);
  }

  addEmployee(data: FormData) {
    return this.httpClient.post(
      MyConfig.address_server + 'Employees/Add',
      data,
      this.config.getHttpHeaderOption()
    );
  }

  editEmployee(data: FormData) {
    return this.httpClient.put(
      MyConfig.address_server + 'Employees/Edit/' + data.get('id'),
      data,
      this.config.getHttpHeaderOption()
    );
  }

  deactivate(id: any) {
    return this.httpClient.put(
      MyConfig.address_server + this.controllerName + '/Deactivate?id=' + id,
      id,
      this.config.getHttpHeaderOption()
    );
  }

  getEmployees() {
    return this.httpClient.get(
      MyConfig.address_server + 'Employees/Get',
      this.config.getHttpHeaderOption()
    );
  }
}
