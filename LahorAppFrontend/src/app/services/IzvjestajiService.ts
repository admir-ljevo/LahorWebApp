import {Injectable} from "@angular/core";
import {ResponseModel} from "../Model/ResponseModel";
import {MyConfig} from "../MyConfig";
import {map} from "rxjs/operators";
import {Obavijest} from "../Model/Obavijest";
import {ResponseCode} from "../enum/ResponseCode";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class IzvjestajiService
{
  constructor(private httpClient: HttpClient, private router: Router) {

  }
  public AddIzvjestaj(noviIzvjestaj:any)
  {
    return this.httpClient.post<ResponseModel>(MyConfig.adresa_servera+ "Izvjestaj/Add",noviIzvjestaj)
      .subscribe((data:any) =>{
        if(data.responseCode==ResponseCode.OK)
        {
          console.log("Izvještaj uspješno dodan ->"+data.dataSet)
          this.router.navigateByUrl("/izvjestaji");
        }
        else
        {
          console.log(data.ResponseMessage);
        }
      });
  }
  public GetAllIzvjestaji()
  {
    return this.httpClient.get<ResponseModel>(MyConfig.adresa_servera+"Izvjestaj/GetAllIzvještaji").pipe(map(res=>{
      let izvjestajiList=new Array<any>();
      if(res.responseCode==ResponseCode.OK)
      {
        if(res.dataSet!=null)
        {
          res.dataSet.map((x:any)=>{
            izvjestajiList.push(x);
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
      return izvjestajiList;
    }));
  }

  public GetVrsteIzvjestaja()
  {
    return this.httpClient.get<ResponseModel>(MyConfig.adresa_servera+"Izvjestaj/GetAllVrsteIzvjestaja").pipe(map(res=>{
      let vrsteIzvjestajaList=new Array<any>();
      if(res.responseCode==ResponseCode.OK)
      {
        if(res.dataSet!=null)
        {
          res.dataSet.map((x:any)=>{
            vrsteIzvjestajaList.push(x);
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
      return vrsteIzvjestajaList;
    }));
  }
}
