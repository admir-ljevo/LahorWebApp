import {HttpClient} from "@angular/common/http";
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import {MyConfig} from "../shared/MyConfig";

export class BaseService {

  news:any;
  controllerName:string;
  constructor(protected httpClient: HttpClient, protected router: Router,ControllerName:string) {
    this.controllerName=ControllerName;
  }
  getAll():Observable<any[]> {
   return this.httpClient.get<any>(MyConfig.address_server + "api/" + this.controllerName + "/", MyConfig.http_options);
  }

  getById(id:Number):Observable<any> {
    return this.httpClient.get<any>(MyConfig.address_server + "api/" + this.controllerName+ "/"+id, MyConfig.http_options);
   }

   post(data:any){
    return this.httpClient.post<any>(MyConfig.address_server + "api/" + this.controllerName+ "/",data,MyConfig.http_options);
  }

  delete(data:any){
    return this.httpClient.delete<any>(MyConfig.address_server + "api/" + this.controllerName+ "/"+data.id,MyConfig.http_options);
  }

  update(data:any){
    return this.httpClient.put<any>(MyConfig.address_server + "api/" + this.controllerName+ "/" +data.id,data).subscribe(
      error=>{
        console.log("There was an error",error);
      }
    );
  }
}
