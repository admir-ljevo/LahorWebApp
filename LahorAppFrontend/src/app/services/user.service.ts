import {Injectable, OnInit} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MyConfig} from "../MyConfig";
import {Router} from "@angular/router";
import {ResponseModel} from "../Model/ResponseModel";
import {map} from "rxjs/operators";
import {ResponseCode} from "../enum/ResponseCode";
import {User} from "../Model/User";
import {AutentifikacijaHelper} from "../_helpers/autentifikacijaHelper";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient, private router: Router) {
  }

  public login(username: string, password: string) {
    const body = {
      Username: username,
      Password: password
    }
    return this.httpClient.post<ResponseModel>(MyConfig.adresa_servera + "User/Login", body, MyConfig.http_opcije).subscribe((data: any) => {
      if(data.responseCode==ResponseCode.OK)
      {
      if (data.dataSet != null) {
        console.log("Logiranje uspješno");
        AutentifikacijaHelper.setLoginInfo(data.dataSet);
       if(data.responseCode=ResponseCode.OK)
       {
         this.router.navigateByUrl("/home")
       }
      }
      } else {
        localStorage.setItem("auth-token", "");
        console.log("Neispravan login -> "+data.ResponseMessage);
      }
    });
  }

  public getUserList() {
    let userInfo = JSON.parse(localStorage.getItem("auth-token"));
    const headers = new HttpHeaders({
        'Authorization': `Bearer ${userInfo?.token}`
      });
    return this.httpClient.get<ResponseModel>(MyConfig.adresa_servera+"User/GetAllUser",{headers:headers}).pipe(map(res=>{
      let userList=new Array<User>();
      if(res.responseCode==ResponseCode.OK)
      {
        if(res.dataSet!=null)
        {
          res.dataSet.map((x:User)=>{
            userList.push(new User(x.userName,x.brojTelefona,x.adresa,x.emailAdresa));
          })
        }
        else
        {
          console.log(res.responseCode);
        }
      }
      else
      {
        console.log(res.responseCode);
      }
      return userList;
    }));
  }
}
