import { Component, OnInit } from '@angular/core';
import {LoginInformation} from "../../_helpers/loginInformacije";
import {AutentifikacijaHelper} from "../../_helpers/autentifikacijaHelper";
import {IzvjestajiService} from "../../services/IzvjestajiService";
import {DatePipe} from "@angular/common";

@Component({
  selector: 'app-izvjestaji',
  templateUrl: './izvjestaji.component.html',
  styleUrls: ['./izvjestaji.component.css']
})
export class IzvjestajiComponent implements OnInit {

  izvjestajiList:any;
  datePipe:DatePipe;
  constructor(private izvjestajiService:IzvjestajiService) { }

  ngOnInit(): void {
    this.preuzmiIzvjestaje();
  }
  p:number=1;
  loginInfo():LoginInformation
  {
    return AutentifikacijaHelper.getLoginInfo();
  }
  preuzmiIzvjestaje()
  {
    this.izvjestajiService.GetAllIzvjestaji().subscribe(
      (data:any)=>{
          this.izvjestajiList=data;
      }
    );
  }
  key:string='datumKreiranja';
  reverse:boolean=false;
  sort(key) {
    this.key=key;
    this.reverse=!this.reverse;
  }
  obrisi(i:any)
  {

  }
  detalji(i:any)
  {

  }
}
