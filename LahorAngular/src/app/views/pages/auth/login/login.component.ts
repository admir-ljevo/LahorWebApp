import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LoginService } from '../../../../services/LoginService';
import { NewModel } from '../../../../models/new-model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthentificationHelper } from 'src/app/helpers/authentification-helper';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  returnUrl: any;
  email: string;
  password: string;
  isFormSubmited: boolean = false;
  isIncorrectAccessData: boolean = false;

  form = new FormGroup({
    userName: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  });

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private loginService: LoginService
  ) {}

  ngOnInit(): void {
    // get return url from route parameters or default to '/'
    //this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  signIn(accessData: any) {
    this.isFormSubmited = true;
    if (this.form.valid) {
      this.loginService.login(accessData).subscribe(
        (data: any) => {
          if (data.user != null && data.token != '') {
            this.isIncorrectAccessData = false;
            AuthentificationHelper.setLoginInfo(data);
            this.router.navigateByUrl('/dashboard');
          } else {
            this.isIncorrectAccessData = true;
          }
        },
        (error) => {
          this.isIncorrectAccessData = true;
          console.log(this.isIncorrectAccessData);
        }
      );
    }
  }

  get formControls() {
    return this.form.controls;
  }
}
