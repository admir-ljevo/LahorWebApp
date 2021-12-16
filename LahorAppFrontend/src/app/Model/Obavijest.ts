

export class Obavijest{
  naslov:string;
  autorId:Number;
  sadrzaj:string;
  javnaObavijest:boolean;
  slika:string;
  datumKreiranja:Date;

  constructor(naslov:string,autorId:Number,sadrzaj:string,javnaObavijest:boolean,
              slika:string,datumKreiranja:Date) {

    this.naslov=naslov;
    this.autorId=autorId;
    this.sadrzaj=sadrzaj;
    this.javnaObavijest=javnaObavijest;
    this.slika=slika;
    this.datumKreiranja=datumKreiranja;
  }
}
