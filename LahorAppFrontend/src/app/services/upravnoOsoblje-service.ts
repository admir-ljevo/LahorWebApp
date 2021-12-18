import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Route} from "@angular/router";
import {ResponseModel} from "../Model/ResponseModel";
import {MyConfig} from "../MyConfig";
import {ResponseCode} from "../enum/ResponseCode";
import {fileURLToPath} from "url";

@Injectable({
  providedIn: 'root'
})
export class UpravnoOsobljeService {

  constructor(private httpClient:HttpClient) {}

  public getUpravnoOsobljeById(id:string) {
    this.httpClient.get<ResponseModel>(MyConfig.adresa_servera+"UpravnoOsoblje/getUpravnoOsobljeById/"+id
    ).subscribe(
      (data:any)=>{
        if(data.responseCode==ResponseCode.OK)
        {
          let upravnoOsoblje;
          if (data.dataSet != null) {
            upravnoOsoblje = data.dataSet;
          }
          console.log(upravnoOsoblje);
          return upravnoOsoblje;
        }
        else
        {
          console.log(data.responseCode);
          return null;
        }
      });
  }
}
