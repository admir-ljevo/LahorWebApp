import { Component, OnInit } from '@angular/core';
import {FormBuilder, Validator, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {UserService} from "../../services/user.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

public loginForm=this.formBuilder.group({
  username:['',Validators.required],
  password:['',Validators.required]
})

  constructor(private formBuilder:FormBuilder,private userService:UserService) { }

  ngOnInit(): void {
  }

  onSubmit()
  {
      this.userService.login(this.loginForm.controls["username"].value,
        this.loginForm.controls["password"].value);
  }

}
