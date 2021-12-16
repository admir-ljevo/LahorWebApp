import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from "@angular/router";
import {Injectable} from "@angular/core";
import {AutentifikacijaHelper} from "../_helpers/autentifikacijaHelper";

@Injectable()
export class AutorizacijaKlijent implements CanActivate{

  constructor(private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

    if (AutentifikacijaHelper.getLoginInfo().role=="Klijent")
      return true;

    // not logged in so redirect to login page with the return url
    this.router.navigate([''], { queryParams: { returnUrl: state.url }});
    return false;
  }
}
