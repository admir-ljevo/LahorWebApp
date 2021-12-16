
import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {ObavijestiServices} from "../../services/obavijesti-services";
import {Obavijest} from "../../Model/Obavijest";
import {AutentifikacijaHelper} from "../../_helpers/autentifikacijaHelper";
import {LoginInformation} from "../../_helpers/loginInformacije";

@Component({
  selector: 'app-obavijesti',
  templateUrl: './obavijesti.component.html',
  styleUrls: ['./obavijesti.component.css']
})
export class ObavijestiComponent implements OnInit {
  constructor(private router:Router,private obavijestiService:ObavijestiServices) { }

  public obavijestiList:any;
  ngOnInit(): void {
    this.getAllObavijesti();
  }
  getAllObavijesti()
  {
    this.obavijestiService.getAllObavijesti().subscribe((data: Obavijest[]) => {
      this.obavijestiList = data;
  });
}
  loginInfo():LoginInformation
  {
    return AutentifikacijaHelper.getLoginInfo();
  }
}
