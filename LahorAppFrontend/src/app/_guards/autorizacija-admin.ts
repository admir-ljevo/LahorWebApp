import {Injectable} from "@angular/core";
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from "@angular/router";
import {AutentifikacijaHelper} from "../_helpers/autentifikacijaHelper";

@Injectable()
export class AutorizacijaAdmin implements CanActivate{

  constructor(private router:Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot)  {
    if(AutentifikacijaHelper.getLoginInfo().role=="Admin")
      return true;
    // not logged in so redirect to login page with the return url
    this.router.navigate([''], { queryParams: { returnUrl: state.url }});
    return false;
  }
}