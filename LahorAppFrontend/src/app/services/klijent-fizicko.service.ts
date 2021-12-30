import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {ResponseModel} from "../Model/ResponseModel";
import {MyConfig} from "../MyConfig";
import {ResponseCode} from "../enum/ResponseCode";

@Injectable({
  providedIn: 'root'
})
export class KlijentFizickoService {

  constructor(private httpClient:HttpClient) {}

  public getKlijentFizickoById(id:string) {
    this.httpClient.get<ResponseModel>(MyConfig.adresa_servera+"KlijentFizickoLice/GetKlijentFizickoById/"+id
      ).subscribe(
      (data:any)=>{
        if(data.responseCode==ResponseCode.OK)
        {
        let klijent;
        if (data.dataSet != null) {
          klijent = data.dataSet;
          console.log(klijent);
        }
        return klijent;
        }
        else
        {
          console.log(data.responseCode);
        }
      });
  }
}
