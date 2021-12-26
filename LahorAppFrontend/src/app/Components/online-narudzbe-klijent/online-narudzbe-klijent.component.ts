import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {LoginInformation} from "../../_helpers/loginInformacije";
import {AutentifikacijaHelper} from "../../_helpers/autentifikacijaHelper";

@Component({
  selector: 'app-online-narudzbe-klijent',
  templateUrl: './online-narudzbe-klijent.component.html',
  styleUrls: ['./online-narudzbe-klijent.component.css']
})
export class OnlineNarudzbeKlijentComponent implements OnInit {

  OnlineNarudzbeList:any;
  p:number=1;
  constructor(private httpClient:HttpClient,private router:Router) { }

  ngOnInit(): void {
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
}
