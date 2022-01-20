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
  public DeleteIzvjestaj(odabraniIzvjestaj:any)
  {
    return this.httpClient.post<ResponseModel>(MyConfig.adresa_servera+ "Izvjestaj/DeleteIzvjestaj/"+odabraniIzvjestaj.id,odabraniIzvjestaj)
      .subscribe((data:any) =>{
        if(data.responseCode==ResponseCode.OK)
        {
          console.log("Izvještaj uspješno obrisan,oznaka izvještaja ->"+data.dataSet.oznaka);
          alert("Izvještaj uspješno obrisan,oznaka izvještaja ->"+data.dataSet.oznaka);
        }
        else
        {
          console.log(data.ResponseMessage);
        }
      });
  }
  public getIzvjestajById(id:Number) {
     this.httpClient.get(MyConfig.adresa_servera+"Izvjestaj/GetIzvjestajById/"+id
    ).subscribe(
      (data:any)=>{

        if(data.responseCode==ResponseCode.OK)
        {
          console.log(data.dataSet);
         return data.dataSet;
        }
        else
        {
          console.log(data.responseCode);
          return null;
        }
      });
  }
  public FilitriranjeIzvjestaja(oznaka:any,datum:any,odabranaVrstaId:any)
  {
    if(oznaka!=null)
    {
    return this.httpClient.get<ResponseModel>(MyConfig.adresa_servera+"Izvjestaj/Filtriranje/"+datum+","+odabranaVrstaId+"?oznaka="+oznaka).pipe(map(res=>{
      let listIzvjestaja=new Array<any>();
      if(res.responseCode==ResponseCode.OK)
      {
        if(res.dataSet!=null)
        {
          res.dataSet.map((x:any)=>{
            listIzvjestaja.push(x);
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
      return listIzvjestaja;
    }));
    }
    else
    {
      return this.httpClient.get<ResponseModel>(MyConfig.adresa_servera+"Izvjestaj/Filtriranje/"+datum+","+odabranaVrstaId).pipe(map(res=>{
        let listIzvjestaja=new Array<any>();
        if(res.responseCode==ResponseCode.OK)
        {
          if(res.dataSet!=null)
          {
            res.dataSet.map((x:any)=>{
              listIzvjestaja.push(x);
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
        return listIzvjestaja;
      }));
    }
  }
}
