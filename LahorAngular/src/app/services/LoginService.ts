import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Router } from '@angular/router';
import {MyConfig} from "../shared/MyConfig";
import {AuthentificationHelper} from "../helpers/authentification-helper";
import {LoginInformation} from "../helpers/login-information";

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
    return this.httpClient.post(MyConfig.address_server + "Access/SignIn", body, MyConfig.http_options).subscribe((data: any) => {
      debugger;
      if (data.user != null && data.token!="") {
        AuthentificationHelper.setLoginInfo(data);
         this.router.navigateByUrl("/dashboard");
      } else {
        console.log("Neispravan login");
      }})
  }
}
