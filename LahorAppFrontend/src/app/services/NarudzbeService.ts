import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {Obavijest} from "../Model/Obavijest";
import {ResponseModel} from "../Model/ResponseModel";
import {MyConfig} from "../MyConfig";
import {ResponseCode} from "../enum/ResponseCode";
import {map} from "rxjs/operators";

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

  public getAllNarudzbe(d:any)
  {
    return this.httpClient.get<ResponseModel>(MyConfig.adresa_servera+"Narudzba/GetAllNarudzbe/"+d).pipe(map(res=>{
      let narudzbeList=new Array<any>();
      if(res.responseCode==ResponseCode.OK)
      {
        if(res.dataSet!=null)
        {
          res.dataSet.map((x:any)=>{
            narudzbeList.push(x);
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
      return narudzbeList;
    }));
  }
  public getAllNarudzbeOdDo(OD:any,DO:any)
  {
    return this.httpClient.get<ResponseModel>(MyConfig.adresa_servera+"Narudzba/GetAllNarudzbeOdDo/"+OD+","+DO).pipe(map(res=>{
      let narudzbeList=new Array<any>();
      if(res.responseCode==ResponseCode.OK)
      {
        if(res.dataSet!=null)
        {
          res.dataSet.map((x:any)=>{
            narudzbeList.push(x);
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
      return narudzbeList;
    }));
  }
  public getAllNarudzbeMjesec(datum:any)
  {
    return this.httpClient.get<ResponseModel>(MyConfig.adresa_servera+"Narudzba/GetAllNarudzbeMjesec/"+datum).pipe(map(res=>{
      let narudzbeList=new Array<any>();
      if(res.responseCode==ResponseCode.OK)
      {
        if(res.dataSet!=null)
        {
          res.dataSet.map((x:any)=>{
            narudzbeList.push(x);
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
      return narudzbeList;
    }));
  }
  public getAllNarudzbeByIzvjestajId(izvjestajId:any)
  {
    return this.httpClient.get<ResponseModel>(MyConfig.adresa_servera+"Narudzba/GetNarudzbeByIzvjestajId/"+izvjestajId).pipe(map(res=>{
      let narudzbeList=new Array<any>();
      if(res.responseCode==ResponseCode.OK)
      {
        if(res.dataSet!=null)
        {
          res.dataSet.map((x:any)=>{
            narudzbeList.push(x);
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
      return narudzbeList;
    }));
  }
}
