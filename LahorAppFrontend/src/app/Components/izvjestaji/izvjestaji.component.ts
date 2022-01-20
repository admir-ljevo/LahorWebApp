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
  styleUrls: ['./izvjestaji.component.css']
})
export class IzvjestajiComponent implements OnInit {

  izvjestajiList:any;
  naslovPretraga:any;
  filterIzvjestaji:any;
  private poruka:string="Hello world";
  private Id:Number=0;
  datePipe:DatePipe;
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
              private router:Router) { }

  ngOnInit(): void {
    this.preuzmiIzvjestaje();
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
   /* this.router.navigateByUrl("pregledIzvjestaja");*/
    this.Id=id;
    //this.router.navigate(["pregledIzvjestaja"],{state:{data:this.Id}})
    this.router.navigate(['pregledIzvjestaja/',id])
    /*  this.narudzbeService.getAllNarudzbeByIzvjestajId(i.id).subscribe(
        (data:any)=> {
          this.urediIzvjestaj.listaNarudzbe = data;
        });
    this.urediIzvjestaj=i;
    this.urediIzvjestaj.prikazi=true;*/
  }

  filterNaslov() {
    if(this.naslovPretraga!="")
    {
      this.filterIzvjestaji= this.izvjestajiList.filter((x:any)=>{
        return x.oznaka.toLocaleLowerCase().match(this.naslovPretraga.toLocaleLowerCase());
      });
    }
    else if(this.naslovPretraga=="")
    {
      this.ngOnInit();
    }
  }
}
