import {BaseService} from "./BaseService";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {ControllerName} from "../constants/ControllerName";
import {MyConfig} from "../shared/MyConfig";
import {Injectable} from "@angular/core";


@Injectable({
  providedIn: 'root'
})
export class MaterialRequestsService extends BaseService{
  constructor(httpClient: HttpClient, router: Router ) {
    super(httpClient, router, ControllerName.MaterialRequests);
  }
  getByRequestId(requestId: number){
    return this.httpClient.get<any>(MyConfig.address_server + ControllerName.MaterialRequests+"/requestId/"+requestId, this.config.getHttpHeaderOption());
  }
}
