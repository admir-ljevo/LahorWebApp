import { Component, OnInit } from '@angular/core';
import {IzvjestajiService} from "../../services/IzvjestajiService";
import {LoginInformation} from "../../_helpers/loginInformacije";
import {AutentifikacijaHelper} from "../../_helpers/autentifikacijaHelper";
import {NarudzbeService} from "../../services/NarudzbeService";
import {UslugaNivoIzvrsenja} from "../../Model/UslugaNivoIzvrsenja";

@Component({
  selector: 'app-dodaj-izvjestaj',
  templateUrl: './dodaj-izvjestaj.component.html',
  styleUrls: ['./dodaj-izvjestaj.component.css']
})
export class DodajIzvjestajComponent implements OnInit {
  vrsteIzvjestaja:any;
  odabranaVrstaIzvjestaja:any;
  odabranaVrstaNaziv:any;
  odabraniDatum:any=new Date().toISOString();
  odabraniDatumOD:any=new Date().toISOString();
  odabraniDatumDO:any=new Date().toISOString();
  odabraniDatumMjesec:any=new Date().toISOString();
  listaNarudzbe:Array<any> = [];

  noviIzvjestaj={
    VrstaIzvjestajaId:0,
    AutorId:this.loginInfo().id,
    Narudzbe:this.listaNarudzbe
}
  constructor(private izvjestajiService:IzvjestajiService,private narudzbeService:NarudzbeService) { }

  ngOnInit(): void {
    this.preuzmiVrsteIzvjestaja();
  }
  preuzmiVrsteIzvjestaja()
  {
      this.izvjestajiService.GetVrsteIzvjestaja().subscribe(
        (data:any)=>{
          this.vrsteIzvjestaja=data;
          this.odabranaVrstaIzvjestaja=this.vrsteIzvjestaja[0].id;
          this.odabranaVrstaNaziv=this.vrsteIzvjestaja[0].naziv;
        }
      );
  }

  preuzmiNarudzbe(d:any)
  {
      this.narudzbeService.getAllNarudzbe(d).subscribe(
        (data:any)=>{
          this.listaNarudzbe=data;
        }
      );
  }
  preuzmiNarudzbeOdDo(datumOD,datumDO)
  {
    this.narudzbeService.getAllNarudzbeOdDo(datumOD,datumDO).subscribe(
      (data:any)=>{
        this.listaNarudzbe=data;
      }
    );
  }

  preuzmiNarudzbeMjesec(datumMjesec)
  {
    this.narudzbeService.getAllNarudzbeMjesec(datumMjesec).subscribe(
      (data:any)=>{
        this.listaNarudzbe=data;
      }
    );
  }
  loginInfo():LoginInformation
  {
    return AutentifikacijaHelper.getLoginInfo();
  }
  dodajIzvjestaj() {
    this.noviIzvjestaj.VrstaIzvjestajaId=this.odabranaVrstaIzvjestaja;
    this.noviIzvjestaj.Narudzbe=this.listaNarudzbe;
      this.izvjestajiService.AddIzvjestaj(this.noviIzvjestaj);
  }
  onSelectedVrsta(vi: any) {
    this.odabranaVrstaIzvjestaja=vi;
    for (let v of this.vrsteIzvjestaja)
    {
      if(v.id==vi)
      {
        this.odabranaVrstaNaziv=v.naziv;
        if(this.odabranaVrstaNaziv=="Dnevni")
        {
          this.preuzmiNarudzbe(this.odabraniDatum);
        }
        else if(this.odabranaVrstaNaziv=="Sedmični")
        {
          this.preuzmiNarudzbeOdDo(this.odabraniDatumOD,this.odabraniDatumDO);
        }
        else if(this.odabranaVrstaNaziv=="Mjesečni")
        {
          this.preuzmiNarudzbeMjesec(this.odabraniDatumMjesec);
        }
        return;
      }
    }

  }
  onSelectedDatum(d:any) {
    this.odabraniDatum=d;
    this.preuzmiNarudzbe(d);
  }

  obrisi(o: any) {

  }

  detalji(o: any) {

  }

  onSelectedDatumOD(datumOD: any) {

    this.odabraniDatumOD=datumOD;
    this.preuzmiNarudzbeOdDo(this.odabraniDatumOD,this.odabraniDatumDO);
  }

  onSelectedDatumDO(datumDO: any) {
    this.odabraniDatumDO=datumDO;
    this.preuzmiNarudzbeOdDo(this.odabraniDatumOD,this.odabraniDatumDO);
  }

  onSelectedDatumMjesec(datumMjesec: any) {
    this.odabraniDatumMjesec=datumMjesec;
    this.preuzmiNarudzbeMjesec(this.odabraniDatumMjesec);
  }
}
