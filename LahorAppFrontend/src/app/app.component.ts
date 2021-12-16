import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {LoginComponent} from "./Components/login/login.component";
import {Router} from "@angular/router";
import {AutentifikacijaHelper} from "./_helpers/autentifikacijaHelper";
import {LoginInformation} from "./_helpers/loginInformacije";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
title='LahorAppFronted'

constructor(private router:Router) {

}
  isUserLogin()
  {
    const user=localStorage.getItem("auth-token");
    return user && user.length>0;
  }
  loginInfo():LoginInformation {
    return AutentifikacijaHelper.getLoginInfo();
  }
  logOut()
  {
    localStorage.clear();
    this.router.navigateByUrl("/login");
  }
}
