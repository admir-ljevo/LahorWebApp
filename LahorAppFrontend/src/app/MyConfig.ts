import {HttpHeaders} from "@angular/common/http";

export class MyConfig{
  static adresa_servera = "https://restapiexample.wrd.app.fit.ba";
  static http_opcije= {
    headers: new HttpHeaders({"Content-Type":"application/json"})
  };
}
