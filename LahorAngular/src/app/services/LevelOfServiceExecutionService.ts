import {BaseService} from "./BaseService";
import {ControllerName} from "../constants/ControllerName";
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})

export class LevelOfServiceExecutionService extends BaseService {
  constructor(httpClient:HttpClient,router:Router){
    super(httpClient,router,ControllerName.LevelOfServiceExecution);
  }
}
