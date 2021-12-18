import {HttpClient} from "@angular/common/http";
import {ResponseModel} from "../Model/ResponseModel";
import {MyConfig} from "../MyConfig";
import {ResponseCode} from "../enum/ResponseCode";
import {map} from "rxjs/operators";
import {Obavijest} from "../Model/Obavijest";
import {Injectable} from "@angular/core";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class ObavijestiServices{

  constructor(private httpClient:HttpClient,private router:Router) {
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
            obavijestList.push(new Obavijest(x.id,x.naslov,x.autorId,x.sadrzaj,x.javnaObavijest,
              x.slika,x.datumKreiranja,false));
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
  public addObavijest(odabranaObavijest:Obavijest)
  {
    return this.httpClient.post<ResponseModel>(MyConfig.adresa_servera+ "Obavijest/Add",odabranaObavijest)
      .subscribe((data:any) =>{
        if(data.responseCode==ResponseCode.OK)
        {
        console.log("Obavijest uspješno dodana ->"+data.dataSet)
          this.router.navigateByUrl("/obavijesti");
        }
        else
        {
          console.log(data.ResponseMessage);
        }
      });
  }

  public DeleteObavijest(odabranaObavijest:Obavijest)
  {
    return this.httpClient.post<ResponseModel>(MyConfig.adresa_servera+ "Obavijest/Obrisi/"+odabranaObavijest.id,odabranaObavijest)
      .subscribe((data:any) =>{
        if(data.responseCode==ResponseCode.OK)
        {
          console.log("Obavijest uspješno obrisana,naslov obavijesti ->"+data.dataSet.naslov);
          alert("Obavijest uspješno obrisana,naslov obavijesti ->"+data.dataSet.naslov);
        }
        else
        {
          console.log(data.ResponseMessage);
        }
      });
  }
}
