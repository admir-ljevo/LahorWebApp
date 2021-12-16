import {HttpHeaders} from "@angular/common/http";

export class MyConfig{
  static adresa_servera = "https://localhost:44339/";
  static http_opcije= {
    headers: new HttpHeaders({
      "Content-Type":"application/json"
    })
  };
}
