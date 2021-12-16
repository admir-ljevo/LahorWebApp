import {ResponseModel} from "../Model/ResponseModel";
import {LoginInformation} from "./loginInformacije";

export class AutentifikacijaHelper{

  static setLoginInfo(x:LoginInformation):void
{
    if(x==null)
    {
      x=new LoginInformation();
    }
    localStorage.setItem("auth-token",JSON.stringify(x));
}

static getLoginInfo():LoginInformation
  {
    let x = localStorage.getItem("auth-token");
    if (x==="")
      return new LoginInformation();

    try {
      let loginInformation:LoginInformation = JSON.parse(x);
      return loginInformation;
    }
    catch (e)
    {
      return new LoginInformation();
    }
  }
}

