import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {LoginInformation} from "../../_helpers/loginInformacije";
import {AutentifikacijaHelper} from "../../_helpers/autentifikacijaHelper";

@Component({
  selector: 'app-online-narudzbe',
  templateUrl: './online-narudzbe.component.html',
  styleUrls: ['./online-narudzbe.component.css']
})
export class OnlineNarudzbeComponent implements OnInit {


  constructor(private httpClient:HttpClient,private router:Router) { }

  ngOnInit(): void {
  }
}
