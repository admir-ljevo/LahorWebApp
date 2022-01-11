import { Component, OnInit } from '@angular/core';
import {IzvjestajiService} from "../../services/IzvjestajiService";

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

  noviIzvjestaj={
    VrstaIzvjestajaId:0,
    AutorId:0
}
  constructor(private izvjestajiService:IzvjestajiService) { }

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
  dodajIzvjestaj() {

  }
  onSelectedVrsta(vi: any) {
    this.odabranaVrstaIzvjestaja=vi;

  }
  onSelectedDatum(d:any) {
    this.odabraniDatum=d;
  }
}
