import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {LoginInformation} from "../../_helpers/loginInformacije";
import {AutentifikacijaHelper} from "../../_helpers/autentifikacijaHelper";
import {MyConfig} from "../../MyConfig";

@Component({
  selector: 'app-online-narudzbe',
  templateUrl: './online-narudzbe.component.html',
  styleUrls: ['./online-narudzbe.component.css']
})
export class OnlineNarudzbeComponent implements OnInit {

  OnlineNarudzbeList:any;
  p:number=1;
  onlineNarudzbe:any;
  constructor(private httpClient:HttpClient,private router:Router) { }

  ngOnInit(): void {
    this.preuzmiOnlineNarudzbe();
  }

  loginInfo():LoginInformation
  {
    return AutentifikacijaHelper.getLoginInfo();
  }
  key:string='datumKreiranja';
  reverse:boolean=false;
  sort(key) {
    this.key=key;
    this.reverse=!this.reverse;
  }

  obrisi(o: any) {

  }

  detalji(o: any) {

  }

  private preuzmiOnlineNarudzbe() {
    this.httpClient.get(MyConfig.adresa_servera+"Narudzba/GetAllNarudzbeOnline",MyConfig.http_opcije).subscribe(
      (data:any)=>{
        this.OnlineNarudzbeList=data.dataSet;

      }
    );
  }
}
