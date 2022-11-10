import { LoginInformation } from './login-information';

export class AuthentificationHelper {
  static setLoginInfo(x: LoginInformation): void {
    if (x == null) {
      x = new LoginInformation();
    }
    localStorage.setItem('auth-token', JSON.stringify(x));
    localStorage.setItem('user-id', x.user.id);
    localStorage.setItem('user-firstName', x.user.person.firstName);
    localStorage.setItem('user-lastName', x.user.person.lastName);
    localStorage.setItem('user-username', x.user.username);
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
}
