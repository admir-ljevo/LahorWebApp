import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {Obavijest} from "../Model/Obavijest";
import {ResponseModel} from "../Model/ResponseModel";
import {MyConfig} from "../MyConfig";
import {ResponseCode} from "../enum/ResponseCode";

@Injectable({
  providedIn: 'root'
})
export class NarudzbeService{
  constructor(private httpClient: HttpClient, private router: Router) {
  }

  public addOnlineNarudzba(novaNarudzba:any)
  {
    return this.httpClient.post<ResponseModel>(MyConfig.adresa_servera+ "Narudzba/AddOnlineNarudzba",novaNarudzba)
      .subscribe((data:any) =>{
        if(data.responseCode==ResponseCode.OK)
        {
          console.log("Online narudzba uspješno dodana ->"+data.dataSet)
          this.router.navigateByUrl("/onlineNarudzbeKlijent");
        }
        else
        {
          console.log(data.ResponseMessage);
        }
      });
  }
}
