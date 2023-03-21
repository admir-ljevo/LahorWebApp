import {Injectable} from "@angular/core";
import {BaseService} from "./BaseService";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {ControllerName} from "../constants/ControllerName";
import {MyConfig} from "../shared/MyConfig";


@Injectable({
  providedIn:'root'
})
export class MaterialsService extends BaseService{
constructor(httpClient: HttpClient, router: Router) {
  super(httpClient,router,ControllerName.Material);
}
getMaterialsSorted(sortCol: string, sortDir: string, nameFilter: string | null = null){
  return this.httpClient.get<any>(MyConfig.address_server+ControllerName.Material+"/sortCol/" + sortCol+"/sortDir/" + sortDir + "/nameFilter/" + nameFilter, this.config.getHttpHeaderOption());
}
}
