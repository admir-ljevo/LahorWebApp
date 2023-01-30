import { Injectable } from '@angular/core';
import {
  CanActivate,
  RouterStateSnapshot,
  ActivatedRouteSnapshot,
} from '@angular/router';
import { Router } from '@angular/router';
import { AuthentificationHelper } from 'src/app/helpers/authentification-helper';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let token = AuthentificationHelper.getToken();
    if (AuthentificationHelper.getToken() != null) {
      const expiry = JSON.parse(atob(token.split('.')[1])).exp;
      if (expiry * 1000 > Date.now()) {
        return true;
      }
    }

    // not logged in so redirect to login page with the return url
    this.router.navigate(['/auth/login'], {
      queryParams: { returnUrl: state.url },
    });
    return false;
  }

  static isActive(): boolean {
    let token = AuthentificationHelper.getToken();
    if (AuthentificationHelper.getToken() != null) {
      const expiry = JSON.parse(atob(token.split('.')[1])).exp;
      if (expiry * 1000 > Date.now()) {
        return true;
      }
      return false;
    }
    return false;
  }
}
