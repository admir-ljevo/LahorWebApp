import { Injectable } from '@angular/core';
import {
  CanActivate,
  RouterStateSnapshot,
  ActivatedRouteSnapshot,
} from '@angular/router';
import { Router } from '@angular/router';

@Injectable()
export class AuthAdminGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let isAdmin = localStorage.getItem('user-isAdmin') === 'true';
    if (isAdmin) {
      return true;
    }
    // not logged in so redirect to login page with the return url
    this.router.navigate(['/dashboard'], {
      queryParams: { returnUrl: state.url },
    });
    return false;
  }

  static isActive(): boolean {
    return localStorage.getItem('user-isAdmin') === 'true';
  }
}
