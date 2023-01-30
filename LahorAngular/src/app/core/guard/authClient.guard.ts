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
import { AuthEmployeeGuard } from './authEmployee.guard';

@Injectable()
export class AuthClientGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let isClient = localStorage.getItem('user-isClient') === 'true';
    let isEmployee = AuthEmployeeGuard.isActive();
    let isAuthorize = AuthGuard.isActive();
    let isCompanyOwner = AuthCompanyOwnerGuard.isActive();
    let isAdmin = AuthAdminGuard.isActive();
    if (isAuthorize && (isClient || isEmployee || isCompanyOwner || isAdmin)) {
      return true;
    }

    // not logged in so redirect to login page with the return url
    this.router.navigate(['/dashboard'], {
      queryParams: { returnUrl: state.url },
    });
    return false;
  }

  static isActive(): boolean {
    return localStorage.getItem('user-isClient') === 'true';
  }
}
