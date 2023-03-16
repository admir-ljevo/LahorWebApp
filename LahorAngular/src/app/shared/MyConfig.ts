import {HttpHeaders} from "@angular/common/http";

export class MyConfig{
  static address_server = "https://localhost:44344/";
  static http_options= {
    headers: new HttpHeaders({
      "Content-Type":"application/json"
    })
  };
  static http_options2= {
    headers: new HttpHeaders({
      "Content-Type":"multipart/form-data"
    })
  };
}
