export class User{

  public userName:string="";
  public emailAdresa:string="";
  public brojTelefona:string="";
  public adresa:string="";

  constructor(UserName:string,BrojTelefona:string,Adresa:string,Email:string )
  {
    this.userName=UserName;
    this.brojTelefona=BrojTelefona;
    this.adresa=Adresa;
    this.emailAdresa=Email;
  }
}
