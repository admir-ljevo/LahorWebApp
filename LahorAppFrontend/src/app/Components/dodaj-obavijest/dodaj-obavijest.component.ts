import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Obavijest} from "../../Model/Obavijest";
import {ObavijestiServices} from "../../services/obavijesti-services";
import {AutentifikacijaHelper} from "../../_helpers/autentifikacijaHelper";
import {UpravnoOsobljeService} from "../../services/upravnoOsoblje-service";
import {ResponseModel} from "../../Model/ResponseModel";
import {MyConfig} from "../../MyConfig";
import {ResponseCode} from "../../enum/ResponseCode";

@Component({
  selector: 'app-dodaj-obavijest',
  templateUrl: './dodaj-obavijest.component.html',
  styleUrls: ['./dodaj-obavijest.component.css']
})
export class DodajObavijestComponent implements OnInit {

  constructor(private httpClient: HttpClient, private obavijestService:ObavijestiServices,
              private upravnoOsobljeService:UpravnoOsobljeService) {

  }
  public odabranaObavijest:Obavijest=new Obavijest(0,"",AutentifikacijaHelper.getLoginInfo().id,
    "",false,"",new Date(),false);

  ngOnInit(): void {
  }
  dodajObavijest() {
    this.obavijestService.addObavijest(this.odabranaObavijest);
  }

}
