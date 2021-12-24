
import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {ObavijestiServices} from "../../services/obavijesti-services";
import {Obavijest} from "../../Model/Obavijest";
import {AutentifikacijaHelper} from "../../_helpers/autentifikacijaHelper";
import {LoginInformation} from "../../_helpers/loginInformacije";
import {ResponseModel} from "../../Model/ResponseModel";
import {MyConfig} from "../../MyConfig";
import {ResponseCode} from "../../enum/ResponseCode";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-obavijesti',
  templateUrl: './obavijesti.component.html',
  styleUrls: ['./obavijesti.component.css']
})
export class ObavijestiComponent implements OnInit {
  constructor(private router:Router,private obavijestiService:ObavijestiServices,private httpClient:HttpClient) { }

  obavijestiList:any;
  filterObavList:any;
  odabranaObavijest:any;
  naslovPretraga:any;
  /*listaBracniStatusi:any;*/
  p:number=1;
  ngOnInit():void {
       this.PreuzmiSveObavjesti();
       /*this.PreuzmiBracneStatuse();*/
  }
  PreuzmiSveObavjesti()
  {
    this.obavijestiService.getAllObavijesti().subscribe((data: Obavijest[]) => {
      this.obavijestiList = data;
      this.filterObavList=this.obavijestiList;
  });
  }
  filterNaslov()
  {
    if(this.naslovPretraga!="")
    {
   this.filterObavList= this.obavijestiList.filter((x:any)=>{
     return x.naslov.toLocaleLowerCase().match(this.naslovPretraga.toLocaleLowerCase());
   });
    }
    else if(this.naslovPretraga=="")
    {
      this.ngOnInit();
    }
  }

  loginInfo():LoginInformation
  {
    return AutentifikacijaHelper.getLoginInfo();
  }

  detalji(o:any)
  {
    this.odabranaObavijest=o;
    this.odabranaObavijest.prikazi=true;
  }

  obrisi(o: any) {
    this.obavijestiService.DeleteObavijest(o);
    const index = this.obavijestiList.indexOf(o);
    if (index > -1) {
      this.obavijestiList.splice(index, 1);
    }
  }
  key:string='datumKreiranja';
  reverse:boolean=false;
  sort(key) {
    this.key=key;
    this.reverse=!this.reverse;
  }

  /*PreuzmiBracneStatuse() {
    this.httpClient.get(MyConfig.adresa_servera+"BracniStatusi/GetAllCmb",MyConfig.http_opcije).subscribe(
      (data:any)=>{
        this.listaBracniStatusi=data;
        }
      );
  }*/
}
