import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from "@angular/router";
import {AutentifikacijaHelper} from "../_helpers/autentifikacijaHelper";
import {Injectable} from "@angular/core";

@Injectable()
export class AutorizacijaLogin implements CanActivate{
  constructor(private router:Router) {}

    canActivate(route: ActivatedRouteSnapshot, state:RouterStateSnapshot)
    {
      if(AutentifikacijaHelper.getLoginInfo()!=null)
        return true;

      this.router.navigateByUrl("/login");
      return false;
    }
  }

