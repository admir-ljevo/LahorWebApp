import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {LoginService} from "../../../../services/LoginService";
import {NewModel} from "../../../../models/new-model";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  returnUrl: any;
  email:string;
  password:string;

  constructor(private router: Router, private route: ActivatedRoute,private loginService:LoginService) { }

  ngOnInit(): void {
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  signIn() {
    debugger;
    this.loginService.login(this.email,this.password);
  }

}
