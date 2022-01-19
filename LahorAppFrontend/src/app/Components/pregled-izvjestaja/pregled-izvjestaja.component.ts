import {Component, Input, OnInit} from '@angular/core';
import {LoginInformation} from "../../_helpers/loginInformacije";
import {AutentifikacijaHelper} from "../../_helpers/autentifikacijaHelper";
import {NarudzbeService} from "../../services/NarudzbeService";
import {IzvjestajiService} from "../../services/IzvjestajiService";
import {MyConfig} from "../../MyConfig";
import {HttpClient} from "@angular/common/http";



@Component({
  selector: 'app-pregled-izvjestaja',
  templateUrl: './pregled-izvjestaja.component.html',
  styleUrls: ['./pregled-izvjestaja.component.css']
})
export class PregledIzvjestajaComponent implements OnInit {
  izvjestaj:any=null;
  listaNarudzbe:any;
  id:Number;
  constructor(private service:NarudzbeService,private izvjestajService:IzvjestajiService,private httpClient:HttpClient) {

  }

  ngOnInit(): void {
    var id=history.state.data;
   this.httpClient.get(MyConfig.adresa_servera+"Izvjestaj/GetIzvjestajById/"+id
    ).subscribe(
      (data:any)=>{
        this.izvjestaj=data.dataSet;
      });
   /* this.getIzvjestajPodaci(id);*/
    this.getNarudzbe(id);
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

  private getNarudzbe(id: Number) {
    this.service.getAllNarudzbeByIzvjestajId(id).subscribe(
      (data:any)=>{
        this.listaNarudzbe=data;
      });
  }

  private getIzvjestajPodaci(id: any) {
   this.izvjestaj=this.izvjestajService.getIzvjestajById(id);
  }
}
