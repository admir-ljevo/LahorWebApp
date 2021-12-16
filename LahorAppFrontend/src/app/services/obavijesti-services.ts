import {HttpClient} from "@angular/common/http";
import {ResponseModel} from "../Model/ResponseModel";
import {MyConfig} from "../MyConfig";
import {ResponseCode} from "../enum/ResponseCode";
import {map} from "rxjs/operators";
import {Obavijest} from "../Model/Obavijest";
import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class ObavijestiServices{

  constructor(private httpClient:HttpClient) {
  }

  public getAllObavijesti()
  {
    return this.httpClient.get<ResponseModel>(MyConfig.adresa_servera+"Obavijest/GetAllObavijesti").pipe(map(res=>{
      let obavijestList=new Array<Obavijest>();
      if(res.responseCode==ResponseCode.OK)
      {
        if(res.dataSet!=null)
        {
          res.dataSet.map((x:Obavijest)=>{
            obavijestList.push(new Obavijest(x.naslov,x.autorId,x.sadrzaj,x.javnaObavijest,
              x.slika,x.datumKreiranja));
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
      return obavijestList;
    }));
  }
}
