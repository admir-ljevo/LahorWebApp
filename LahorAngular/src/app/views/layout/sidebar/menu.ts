import { AuthGuard } from 'src/app/core/guard/auth.guard';
import { AuthAdminGuard } from 'src/app/core/guard/authAdmin.guard';
import { AuthClientGuard } from 'src/app/core/guard/authClient.guard';
import { AuthCompanyOwnerGuard } from 'src/app/core/guard/authCompanyOwner.guard';
import { AuthEmployeeGuard } from 'src/app/core/guard/authEmployee.guard';
import { MenuItem } from './menu.model';

export class getMenu {
  getMenuItems(): any {
    return this.menuItems;
  }

  menuItems: MenuItem[] = [
    {
      label: 'MENU.TITLE',
      isTitle: true,
      display: true,
    },
    {
      label: 'MENU.DASHBOARD',
      icon: 'home',
      link: '/dashboard',
      display: true,
    },
    {
      label: 'MENU.NEWS',
      icon: 'bookmark',
      link: '/news',
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() ||
          AuthEmployeeGuard.isActive() ||
          AuthCompanyOwnerGuard.isActive()),
    },
    {
      label: 'MENU.SERVICES',
      icon: 'shopping-cart',
      link: '/services',
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() ||
          AuthEmployeeGuard.isActive() ||
          AuthCompanyOwnerGuard.isActive()),
    },
    {
      label: 'MENU.PRICE_LIST',
      icon: 'book-open',
      link: '/price-list-preview',
      display: AuthGuard.isActive(),
    },
    {
      label: 'MENU.REPORTING',
      icon: 'file-text',
      link: '/reporting',
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() ||
          AuthEmployeeGuard.isActive() ||
          AuthCompanyOwnerGuard.isActive()),
    },
    {
      label: 'MENU.EMPLOYEES',
      icon: 'users',
      link: '/employees',
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() || AuthCompanyOwnerGuard.isActive()),
    },
    {
      label: 'MENU.CLIENTS',
      icon: 'users',
      link: '/clients',
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() ||
          AuthEmployeeGuard.isActive() ||
          AuthCompanyOwnerGuard.isActive()),
    },
    {
      label: 'MENU.REGIONAL_SETTINGS',
      isTitle: true,
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() || AuthCompanyOwnerGuard.isActive()),
    },
    {
      label: 'MENU.COUNTRIES',
      icon: 'globe',
      link: '/countries',
      display: AuthGuard.isActive() && AuthAdminGuard.isActive(),
    },
    {
      label: 'MENU.CITIES',
      icon: 'globe',
      link: '/cities',
      display: AuthGuard.isActive() && AuthAdminGuard.isActive(),
    },
  ];
}
