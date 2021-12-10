import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MyConfig} from "../MyConfig";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient:HttpClient,private router:Router) { }

  public login(username:string,password:string)
  {
    const body={
      Username:username,
      Password:password
    }
    return this.httpClient.post(MyConfig.adresa_servera+"User/Login",body,MyConfig.http_opcije).
      subscribe((data:any)=>{
      if(data.dataSet!=null)
      {
        console.log("uspješan login");
        localStorage.setItem("auth-token",data.dataSet.token);
        if( data.responseCode==1 && data.dataSet.korisnik.isKlijentFizickoLice==true)
        {
        this.router.navigateByUrl("/klijent");
        }
        else if(data.responseCode==1 && data.dataSet.korisnik.isKlijentPravnoLice==true)
        {
          this.router.navigateByUrl("/klijent");
        }
        else if(data.responseCode==1 && data.dataSet.korisnik.isUposlenik==true)
        {
          this.router.navigateByUrl("/uposlenik");
        }
        else if(data.responseCode==1 && data.dataSet.korisnik.isUpravnoOsoblje==true)
        {
          this.router.navigateByUrl("/upravnoOsoblje");
        }
        else if(data.responseCode==1 && data.dataSet.korisnik.isAdmin==true)
        {
          this.router.navigateByUrl("/admin");
        }
      }
      else
      {
        localStorage.setItem("auth-token","");
        alert("neispravan login");
      }
  });
  }
}
