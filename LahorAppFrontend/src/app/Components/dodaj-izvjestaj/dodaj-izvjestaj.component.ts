import { Component, OnInit } from '@angular/core';
import {IzvjestajiService} from "../../services/IzvjestajiService";
import {LoginInformation} from "../../_helpers/loginInformacije";
import {AutentifikacijaHelper} from "../../_helpers/autentifikacijaHelper";
import {NarudzbeService} from "../../services/NarudzbeService";

@Component({
  selector: 'app-dodaj-izvjestaj',
  templateUrl: './dodaj-izvjestaj.component.html',
  styleUrls: ['./dodaj-izvjestaj.component.css']
})
export class DodajIzvjestajComponent implements OnInit {

  odabraniIzvjestaj:any;
  vrsteIzvjestaja:any;
  odabranaVrstaIzvjestaja:any;
  odabraniDatum:any;
  listaNarudzbe:any;

  noviIzvjestaj={
    VrstaIzvjestajaId:0,
    AutorId:0
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
  loginInfo():LoginInformation
  {
    return AutentifikacijaHelper.getLoginInfo();
  }
  dodajIzvjestaj() {

  }
  onSelectedVrsta(vi: any) {
    this.odabranaVrstaIzvjestaja=vi;

  }
  onSelectedDatum(d:any) {
    this.odabraniDatum=d;
    this.preuzmiNarudzbe(d);
  }

  obrisi(o: any) {

  }

  detalji(o: any) {

  }
}
