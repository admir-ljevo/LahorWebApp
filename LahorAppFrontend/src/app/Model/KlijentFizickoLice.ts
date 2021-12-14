import {Klijent} from "./Klijent";

export class KlijentFizickoLice extends Klijent {

  public id:Number;
  public ime:string;
  public prezime:string;
  public datumRodjenja:Date;
  public spolId:Number;
  public korisnikID:string;

  constructor(id:Number,ime:string,prezime:string,datumRodjenja:Date,spolID:Number,korisnikId:string,
              clanskaKartica:boolean,aktivan:boolean) {
    super(aktivan,clanskaKartica);

    this.id=id;
    this.ime=ime;
    this.prezime=prezime;
    this.datumRodjenja=datumRodjenja;
    this.spolId=spolID;
    this.korisnikID=korisnikId;
  }
}
