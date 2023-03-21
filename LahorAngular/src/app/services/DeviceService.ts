import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Router } from '@angular/router';
import { BaseService } from './BaseService';
import { ControllerName } from '../constants/ControllerName';
import {MyConfig} from "../shared/MyConfig";

@Injectable({
  providedIn: 'root'
})
export class DeviceService extends  BaseService {
  constructor(httpClient: HttpClient, router: Router) {
    super(httpClient, router, ControllerName.Device);
  }
  getDevicesSorted(sortCol: string, sortDir: string){
    return this.httpClient.get<any>(MyConfig.address_server + ControllerName.Device + "/sortCol" + "/"+sortCol + "/sortDir/" + sortDir, this.config.getHttpHeaderOption());
  }
}
