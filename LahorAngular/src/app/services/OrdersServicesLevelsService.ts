import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Router } from '@angular/router';
import { BaseService } from './BaseService';
import { ControllerName } from '../constants/ControllerName';
import {Observable} from "rxjs";
import {MyConfig} from "../shared/MyConfig";

@Injectable({
  providedIn: 'root'
})
export class OrdersServicesLevelsService extends BaseService {
  constructor(httpClient: HttpClient, router: Router) {
    super(httpClient, router, ControllerName.OrdersServicesLevels);
  }
getByOrderId(orderId: Number){
    return this.httpClient.get<any>(MyConfig.address_server + "api/" + ControllerName.OrdersServicesLevels + "/orderId" + "/"+orderId, MyConfig.http_options);
}

}
