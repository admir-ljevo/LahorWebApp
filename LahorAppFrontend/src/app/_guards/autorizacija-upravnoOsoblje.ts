import {AutentifikacijaHelper} from "../_helpers/autentifikacijaHelper";
import {Injectable} from "@angular/core";
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from "@angular/router";

@Injectable()
export class AutorizacijaUpravnoOsoblje implements CanActivate{

  constructor(private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

    if (AutentifikacijaHelper.getLoginInfo().role=="UpravnoOsoblje")
      return true;

    // not logged in so redirect to login page with the return url
    this.router.navigate([''], { queryParams: { returnUrl: state.url }});
    return false;
  }
}
