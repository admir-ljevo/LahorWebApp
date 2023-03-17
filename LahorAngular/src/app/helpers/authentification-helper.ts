import { LoginInformation } from './login-information';

export class AuthentificationHelper {
  static setLoginInfo(x: LoginInformation): void {
    if (x == null) {
      x = new LoginInformation();
      return;
    }
    localStorage.clear();
    localStorage.setItem('auth-token', JSON.stringify(x.token));
    localStorage.setItem('user-id', x.user.id);
    localStorage.setItem('user-firstName', x.user.person.firstName);
    localStorage.setItem('user-lastName', x.user.person.lastName);
    localStorage.setItem('user-username', x.user.username);
    localStorage.setItem('user-email', x.user.email);
    localStorage.setItem('user-profilePhoto', x.user.person.profilePhoto);
    localStorage.setItem('user-isAdmin', x.user.isAdministrator);
    localStorage.setItem('user-isCompanyOwner', x.user.isCompanyOwner);
    localStorage.setItem('user-isEmployee', x.user.isEmployee);
    localStorage.setItem('user-isClient', x.user.isClient);
  }

  static getLoginInfo(): LoginInformation {
    let x = localStorage.getItem('auth-token')!;
    if (x === '') return new LoginInformation();

    try {
      let loginInformation: LoginInformation = JSON.parse(x);
      return loginInformation;
    } catch (e) {
      return new LoginInformation();
    }
  }

  static getToken(): any {
    if (!localStorage.getItem('auth-token')) return null;
    let token = localStorage.getItem('auth-token')?.slice(1, -1);
    if (token == '') return false;
    return `Bearer ${token}`;
  }
}
