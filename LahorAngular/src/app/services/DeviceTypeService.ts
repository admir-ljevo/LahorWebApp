import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Router } from '@angular/router';
import { BaseService } from './BaseService';
import { ControllerName } from '../constants/ControllerName';

@Injectable({
  providedIn: 'root'
})
export class DeviceTypeService extends BaseService {
  constructor(httpClient: HttpClient, router: Router) {
    super(httpClient, router, ControllerName.DeviceType);
  }

}
