import { HttpHeaders } from '@angular/common/http';
import { AuthentificationHelper } from '../helpers/authentification-helper';

/*export class MyConfig{
  static address_server = "https://localhost:44344/";*/

export class MyConfig {
  // static address_server = 'https://api.p2100.app.fit.ba/api/';
  static address_server_base = "https://localhost:44344/"
  static address_server = "https://localhost:44344/api/";

  //static address_server_base = 'https://api.p2100.app.fit.ba/';
  //static address_server = 'https://localhost:7133/api/';
  //static address_server_base = 'https://localhost:7133/';
  static http_options_multipart_form_data = {
    headers: new HttpHeaders({ 
      'Content-Type': 'multipart/form-data',
    }),
  };

  static http_options_json = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  static http_options_response_blob = {
    responseType: 'blob' as 'json',
  };

  getHttpHeaderOption() {
    return {
      headers: new HttpHeaders({
        Authorization: AuthentificationHelper.getToken(),
      }),
    };
  }
}



