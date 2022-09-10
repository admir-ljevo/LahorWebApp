import {Injectable, OnInit} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import { Router } from '@angular/router';
import { AuthentificationHelper } from './helpers/authentification-helper';
import { LoginInformation } from './helpers/login-information';
import {MyConfig} from "../../../_metronic/shared/MyConfig";

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient, private router: Router) {
  }

  public login(email: string, password: string) {
    const body = {
      Email: email,
      Password: password
    }
    // @ts-ignore
    return this.httpClient.post(MyConfig.address_server + "Access/SignIn", body, MyConfig.http_options);
  }
}
