import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BaseService } from './BaseService';
import { ControllerName } from '../constants/ControllerName';
import { MyConfig } from '../shared/MyConfig';

@Injectable({
  providedIn: 'root',
})
export class ClientsService extends BaseService {
  constructor(httpClient: HttpClient, router: Router) {
    super(httpClient, router, ControllerName.Clients);
  }

  getClients() {
    return this.httpClient.get(
      MyConfig.address_server + 'Clients/Get',
      this.config.getHttpHeaderOption()
    );
  }

  addClient(data: any) {
    return this.httpClient.post(
      MyConfig.address_server + this.controllerName + '/Add',
      data
    );
  }
}
