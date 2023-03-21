import {BaseService} from "./BaseService";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {Injectable} from "@angular/core";
import {ControllerName} from "../constants/ControllerName";
import {Observable} from "rxjs";
import {MyConfig} from "../shared/MyConfig";

@Injectable({
  providedIn: 'root'
})
export class PurchaseRequestService extends BaseService{
  constructor(httpClient: HttpClient, router: Router) {
    super(httpClient, router, ControllerName.PurchaseRequest);
  }
   getPaginated(search:string,pageSize:any,pageNumber:any):Observable<any[]>
  {
    return this.httpClient.get<any>(MyConfig.address_server+ControllerName.PurchaseRequest+"/"+pageNumber+"/"+pageSize+"?SearchFilter="+search,this.config.getHttpHeaderOption());
  }
}
