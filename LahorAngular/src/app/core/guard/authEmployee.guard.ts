import { Injectable } from '@angular/core';
import {
  CanActivate,
  RouterStateSnapshot,
  ActivatedRouteSnapshot,
} from '@angular/router';
import { Router } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { AuthAdminGuard } from './authAdmin.guard';
import { AuthCompanyOwnerGuard } from './authCompanyOwner.guard';

@Injectable()
export class AuthEmployeeGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let isEmployee = localStorage.getItem('user-isEmployee') === 'true';
    let isAuthorize = AuthGuard.isActive();
    let isCompanyOwner = AuthCompanyOwnerGuard.isActive();
    let isAdmin = AuthAdminGuard.isActive();
    if ((isEmployee || isCompanyOwner || isAdmin) && isAuthorize) {
      return true;
    }

    // not logged in so redirect to login page with the return url
    this.router.navigate(['/dashboard'], {
      queryParams: { returnUrl: state.url },
    });
    return false;
  }

  static isActive(): boolean {
    return localStorage.getItem('user-isEmployee') === 'true';
  }
}
