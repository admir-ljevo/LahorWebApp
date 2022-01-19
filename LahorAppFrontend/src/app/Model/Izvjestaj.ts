export class Izvjestaj{
  public id:Number;
  public oznaka:string=" ";
  public vrstaIzvjestajaId:Number=0;
  public datumKreiranja:string=" ";
  public nazivVrsteIzvjestaja:string=" ";
  public autorNaziv:string=" ";
  public listaNarudzbe:any;

  constructor(id:Number,oznaka:string,vrstaIzvjestajaId:Number,datumKreiranja:string,nazivVrtsteIzvjestaja:string,
              autorMaziv:string) {

    this.id=id;
    this.oznaka=oznaka;
    this.vrstaIzvjestajaId=vrstaIzvjestajaId;
    this.datumKreiranja=datumKreiranja;
    this.nazivVrsteIzvjestaja=nazivVrtsteIzvjestaja;
    this.autorNaziv=autorMaziv;
  }
}
