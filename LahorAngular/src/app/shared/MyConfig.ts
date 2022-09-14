import {HttpHeaders} from "@angular/common/http";

export class MyConfig{
  static address_server = "https://localhost:7133/";
  static http_options= {
    headers: new HttpHeaders({
      "Content-Type":"application/json"
    })
  };
}
