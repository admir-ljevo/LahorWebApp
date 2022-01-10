import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {MyConfig} from "../MyConfig";
import {ResponseModel} from "../Model/ResponseModel";
import {map} from "rxjs/operators";
import {ResponseCode} from "../enum/ResponseCode";


@Injectable({
  providedIn: 'root'
})

export class UslugeVrsteService
{
  constructor(private httpClient: HttpClient, private router: Router) {
  }

  public preuzmiUsluge(odabranaVrstaUsluge:Number)
  {
     return this.httpClient.get<ResponseModel>(MyConfig.adresa_servera+"Usluge/GetUslugeCmbByVrsta/"+odabranaVrstaUsluge).pipe(map(res=>{
      let uslugeList=new Array<any>();
      if(res.responseCode==ResponseCode.OK)
      {
        if(res.dataSet!=null)
        {
          res.dataSet.map((x:any)=>{
            uslugeList.push(x);
          })
        }
        else
        {
          console.log(res.responseCode);
        }
      }
      else
      {
        console.log(res.responseCode);
      }
      return uslugeList;
    }));
  }
  public preuzmiVrsteUsluge()
  {
    return this.httpClient.get<ResponseModel>(MyConfig.adresa_servera+"VrsteUsluge/GetAllUslugeCmb").pipe(map(res=>{
      let vrsteUslugeList=new Array<any>();
      if(res.responseCode==ResponseCode.OK)
      {
        if(res.dataSet!=null)
        {
          res.dataSet.map((x:any)=>{
            vrsteUslugeList.push(x);
          })
        }
        else
        {
          console.log(res.responseCode);
        }
      }
      else
      {
        console.log(res.responseCode);
      }
      return vrsteUslugeList;
    }));
  }
  public preuzmiNivoeIzvrsenja()
  {
    return this.httpClient.get<ResponseModel>(MyConfig.adresa_servera+"NivoIzvrsenja/GetAllNivoIzvrsenjaCmb").pipe(map(res=>{
      let nivoiList=new Array<any>();
      if(res.responseCode==ResponseCode.OK)
      {
        if(res.dataSet!=null)
        {
          res.dataSet.map((x:any)=>{
            nivoiList.push(x);
          })
        }
        else
        {
          console.log(res.responseCode);
        }
      }
      else
      {
        console.log(res.responseCode);
      }
      return nivoiList;
    }));
  }
}
