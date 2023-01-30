import { Injectable } from '@angular/core';
import {
  CanActivate,
  RouterStateSnapshot,
  ActivatedRouteSnapshot,
} from '@angular/router';
import { Router } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { AuthAdminGuard } from './authAdmin.guard';

@Injectable()
export class AuthCompanyOwnerGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let isCompanyOwner = localStorage.getItem('user-isCompanyOwner') === 'true';
    let isAuthorize = AuthGuard.isActive();
    let isAdmin = AuthAdminGuard.isActive();
    if (isAuthorize && (isCompanyOwner || isAdmin)) {
      return true;
    }

    // not logged in so redirect to login page with the return url
    this.router.navigate(['/dashboard'], {
      queryParams: { returnUrl: state.url },
    });
    return false;
  }

  static isActive(): boolean {
    return localStorage.getItem('user-isCompanyOwner') === 'true';
  }
}
