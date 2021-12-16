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
<<<<<<< HEAD
    title(title: any) {
        throw new Error('Method not implemented.');
    }
=======
title='LahorAppFronted'
>>>>>>> 7313aae6db0a7c8cd26a09fba1484c30fcdee23d

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
