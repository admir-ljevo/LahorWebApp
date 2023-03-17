import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BaseService } from './BaseService';
import { ControllerName } from '../constants/ControllerName';
import { Observable } from 'rxjs';
import { MyConfig } from '../shared/MyConfig';
import { CountriesCitiesSearchObject } from '../searchObject/CountriesCititesSearchObject';

@Injectable({
  providedIn: 'root',
})
export class AppUsersService extends BaseService {
  constructor(httpClient: HttpClient, router: Router) {
    super(httpClient, router, ControllerName.ApplicationUsers);
  }

  getUserProfile() {
    return this.httpClient.get(
      MyConfig.address_server + this.controllerName + '/GetUserProfile',
      this.config.getHttpHeaderOption()
    );
  }

  changePhoto(file: any) {
    return this.httpClient.put(
      MyConfig.address_server + this.controllerName + '/ChangeProfilePhoto',
      file,
      this.config.getHttpHeaderOption()
    );
  }
}
