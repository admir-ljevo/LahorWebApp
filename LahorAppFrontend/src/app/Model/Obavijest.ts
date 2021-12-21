import {DatePipe} from "@angular/common";


export class Obavijest{
  public id:Number;
  public naslov:string=" ";
  public autorId:Number=0;
  public sadrzaj:string=" ";
  public javnaObavijest:boolean=false;
  public slika:string=" ";
  public datumKreiranja:any;
  public prikazi:boolean=false;

  constructor(id:Number,naslov:string,autorId:Number,sadrzaj:string,javnaObavijest:boolean,
              slika:string,datumKreiranja:any,prikazi:boolean) {

    this.id=id;
    this.naslov=naslov;
    this.autorId=autorId;
    this.sadrzaj=sadrzaj;
    this.javnaObavijest=javnaObavijest;
    this.slika=slika;
    this.datumKreiranja=datumKreiranja;
    this.prikazi=prikazi;
  }
}
