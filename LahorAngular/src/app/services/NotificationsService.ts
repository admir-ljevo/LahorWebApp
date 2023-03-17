import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BaseService } from './BaseService';
import { ControllerName } from '../constants/ControllerName';
import { MyConfig } from '../shared/MyConfig';

@Injectable({
  providedIn: 'root',
})
export class NotificationsService extends BaseService {
  constructor(httpClient: HttpClient, router: Router) {
    super(httpClient, router, ControllerName.Notifications);
  }

  getUnreadNotifications() {
    return this.httpClient.get(
      MyConfig.address_server + this.controllerName + '/GetUnreadNotifications',
      this.config.getHttpHeaderOption()
    );
  }

  MarkAllAsRead() {
    return this.httpClient.post(
      MyConfig.address_server + this.controllerName + '/MarkAllAsRead',
      null,
      this.config.getHttpHeaderOption()
    );
  }
}
