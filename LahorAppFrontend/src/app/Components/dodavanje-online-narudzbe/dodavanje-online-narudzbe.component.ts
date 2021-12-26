import { Component, OnInit } from '@angular/core';
import {LoginInformation} from "../../_helpers/loginInformacije";
import {AutentifikacijaHelper} from "../../_helpers/autentifikacijaHelper";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MyConfig} from "../../MyConfig";
import {UslugaNivoIzvrsenja} from "../../Model/UslugaNivoIzvrsenja";
import {ResponseCode} from "../../enum/ResponseCode";

@Component({
  selector: 'app-dodavanje-online-narudzbe',
  templateUrl: './dodavanje-online-narudzbe.component.html',
  styleUrls: ['./dodavanje-online-narudzbe.component.css']
})
export class DodavanjeOnlineNarudzbeComponent implements OnInit {

  listaUsluge:any;
  vrsteUsluga:any;
  listaNivoiIzvrsenja:any;
  odabranaUsluga:any;
  odabranaVrstaUsluge:any;
  odabraniNivo:any;
  brojac:Number=1;
  listaUslugeNivoIzvrsenja: Array<UslugaNivoIzvrsenja> = [];
  novaNarudzba={
    prikazi:true,
    Id:0,
    Naziv :"",
    Opis:"",
    DatumNarudzbe: new Date(),
    DatumIsporuke: new Date(),
    KlijentId:  this.loginInfo().id,
    UslugeNivoIzvrsenja:this.listaUslugeNivoIzvrsenja
  }
  constructor(private httpClient:HttpClient,private router:Router) { }

  ngOnInit(): void {
    this.preuzmiVrsteUsluga();
    this.preuzmiNivoeIzvrsenja();
  }
  preuzmiUsluge()
  {
    this.httpClient.get(MyConfig.adresa_servera+"Usluge/GetUslugeCmbByVrsta/"+this.odabranaVrstaUsluge,MyConfig.http_opcije).subscribe(
      (data:any)=>{
        this.listaUsluge=data.dataSet;
        this.odabranaUsluga=this.listaUsluge[0].id;
      }
    );
  }
  preuzmiVrsteUsluga()
  {
    this.httpClient.get(MyConfig.adresa_servera+"VrsteUsluge/GetAllUslugeCmb",MyConfig.http_opcije).subscribe(
      (data:any)=>{
        this.vrsteUsluga=data.dataSet;
        this.odabranaVrstaUsluge=this.vrsteUsluga[0].id;
        this.preuzmiUsluge();
      }
    );
  }
  preuzmiNivoeIzvrsenja()
  {
    this.httpClient.get(MyConfig.adresa_servera+"NivoIzvrsenja/GetAllNivoIzvrsenjaCmb",MyConfig.http_opcije).subscribe(
      (data:any)=>{
        this.listaNivoiIzvrsenja=data.dataSet;
        this.odabraniNivo=this.listaNivoiIzvrsenja[0].id;
      }
    );
  }
  dodajNarudzbu() {
    this.httpClient.post(MyConfig.adresa_servera+"Narudzba/AddOnlineNarudzba",this.novaNarudzba,
      MyConfig.http_opcije).subscribe(
      (data:any)=>{
       if(data.responseCode=ResponseCode.OK)
       {
         alert("Narudzba uspjesno dodana");
       }
       else
       {
         alert("Greška" + data.ResponseMessage)
       }
      }
    );
  }

  loginInfo():LoginInformation
  {
    return AutentifikacijaHelper.getLoginInfo();
  }
  detalji(o: any) {

  }

  obrisi(o: any) {

  }
  dodajUslugu() {
    this.listaUslugeNivoIzvrsenja.push(new UslugaNivoIzvrsenja(this.odabranaUsluga,this.odabraniNivo));

  }
  onSelectedUsluga(o: any) {
    this.odabranaUsluga=o;
  }
  onSelectedVrsta(vu: any) {
    this.odabranaVrstaUsluge=vu;
    this.preuzmiUsluge();
  }
  onSelectedOdabraniNivo(on: any) {
    this.odabraniNivo=on;
  }
}
