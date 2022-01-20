import { Component, OnInit } from '@angular/core';
import {LoginInformation} from "../../_helpers/loginInformacije";
import {AutentifikacijaHelper} from "../../_helpers/autentifikacijaHelper";
import {IzvjestajiService} from "../../services/IzvjestajiService";
import {DatePipe} from "@angular/common";
import {NarudzbeService} from "../../services/NarudzbeService";
import {Router} from "@angular/router";
import {Izvjestaj} from "../../Model/Izvjestaj";

@Component({
  selector: 'app-izvjestaji',
  templateUrl: './izvjestaji.component.html',
  styleUrls: ['./izvjestaji.component.css'],
  providers: [DatePipe]
})
export class IzvjestajiComponent implements OnInit {

  izvjestajiList:any;
  naslovPretraga:string=null;
  filterIzvjestaji:any;
  vrsteIzvjestaja:any;
  odabranaVrstaIzvjestaja:any=null;
  odabranaVrstaNaziv:any;
  odabraniDatum:any;
  private poruka:string="Hello world";
  private Id:Number=0;
  urediIzvjestaj={
    id:0,
    oznaka:"",
    vrstaIzvjestajaId:0,
    datumKreiranja:"2003-10-01",
    nazivVrsteIzvjestaja:"",
    autorId:0,
    autorNaziv:0,
    listaNarudzbe:[],
    prikazi:false
  };
  constructor(private izvjestajiService:IzvjestajiService,private narudzbeService:NarudzbeService,
              private router:Router,private datePipe:DatePipe) {
    this.odabraniDatum= this.datePipe.transform(new Date(), 'yyyy-MM-dd');
  }

  ngOnInit(): void {
    this.preuzmiIzvjestaje();
    this.preuzmiVrsteIzvjestaja();
  }
  p:number=1;
  IzvjId:Number;
  loginInfo():LoginInformation
  {
    return AutentifikacijaHelper.getLoginInfo();
  }
  preuzmiIzvjestaje()
  {
    this.izvjestajiService.GetAllIzvjestaji().subscribe(
      (data:any)=>{
          this.izvjestajiList=data;
          this.filterIzvjestaji=this.izvjestajiList;
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
      this.izvjestajiService.DeleteIzvjestaj(i);
    const index = this.izvjestajiList.indexOf(i);
    if (index > -1) {
      this.izvjestajiList.splice(index, 1);
    }
  }
  detalji(id:Number)
  {
    this.Id=id;
    this.router.navigate(['pregledIzvjestaja/',id])
  }

  filtriranje() {
    this.izvjestajiService.FilitriranjeIzvjestaja(this.naslovPretraga,this.odabraniDatum,this.odabranaVrstaIzvjestaja).subscribe(
      (data:any)=>{
        this.filterIzvjestaji=data;
      }
    )
  }

  private preuzmiVrsteIzvjestaja() {
    this.izvjestajiService.GetVrsteIzvjestaja().subscribe(
      (data:any)=>{
        this.vrsteIzvjestaja=data;
        this.odabranaVrstaIzvjestaja=this.vrsteIzvjestaja[0].id;
        this.odabranaVrstaNaziv=this.vrsteIzvjestaja[0].naziv;
      }
    );
  }

  onSelectedVrsta(vi: any) {
    this.odabranaVrstaIzvjestaja=vi;
    for (let v of this.vrsteIzvjestaja)
    {
      if(v.id==vi)
      {
        this.odabranaVrstaNaziv=v.naziv;
      }
    }

    this.filtriranje();

    }

  onSelectedDatum(d: any) {
    this.odabraniDatum=d;
    this.filtriranje();
  }
}
