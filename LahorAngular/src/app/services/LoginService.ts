import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { MyConfig } from '../shared/MyConfig';
import { AuthentificationHelper } from '../helpers/authentification-helper';
import { LoginInformation } from '../helpers/login-information';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private httpClient: HttpClient, private router: Router) {}

  public login(data: any) {
    return this.httpClient.post(
      MyConfig.address_server_base + 'Access/SignIn',
      data
    );
  }
}
