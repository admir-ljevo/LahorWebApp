import {Component, Input, OnInit} from '@angular/core';
import {LoginInformation} from "../../_helpers/loginInformacije";
import {AutentifikacijaHelper} from "../../_helpers/autentifikacijaHelper";
import {NarudzbeService} from "../../services/NarudzbeService";
import {IzvjestajiService} from "../../services/IzvjestajiService";
import {MyConfig} from "../../MyConfig";
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";



@Component({
  selector: 'app-pregled-izvjestaja',
  templateUrl: './pregled-izvjestaja.component.html',
  styleUrls: ['./pregled-izvjestaja.component.css']
})
export class PregledIzvjestajaComponent implements OnInit {
  izvjestaj:any=null;
  listaNarudzbe:any;
  id:any;
  constructor(private service:NarudzbeService,private izvjestajService:IzvjestajiService,private httpClient:HttpClient,
              private route:ActivatedRoute) {

  }

  ngOnInit(): void {
    this.id = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number
    this.getNarudzbe();
    this.getIzvjestajPodaci();
    });

      /*var id=history.state.data;
   /!* this.getIzvjestajPodaci(id);*!/*/
    /*this.getNarudzbe(id);*/
  }

  loginInfo():LoginInformation
  {
    return AutentifikacijaHelper.getLoginInfo();
  }
  p:number=1;
  key:string='datumKreiranja';
  reverse:boolean=false;
  sort(key) {
    this.key = key;
    this.reverse = !this.reverse;
  }

  obrisi(i: any) {

  }

  detalji(i: any) {

  }

  private getNarudzbe() {
    this.service.getAllNarudzbeByIzvjestajId(this.id).subscribe(
      (data:any)=>{
        this.listaNarudzbe=data;
      });
  }

  private getIzvjestajPodaci() {
    this.httpClient.get(MyConfig.adresa_servera+"Izvjestaj/GetIzvjestajById/"+this.id
    ).subscribe(
      (data:any)=>{
        this.izvjestaj=data.dataSet;
      });


  }
}
