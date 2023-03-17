import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { IndividualConfig, ToastrService } from 'ngx-toastr';
import { ClientsService } from 'src/app/services/ClientsService';
import { EnumService } from 'src/app/services/EnumService';
import { TranslationService } from 'src/app/shared/i18n';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  genders: any;
  marriageStatuses: any;
  differentPass: boolean = false;
  message: any;

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private enumService: EnumService,
    private clientsService: ClientsService,
    private t: TranslationService,
    private toastr: ToastrService,
    private formatter: NgbDateParserFormatter
  ) {}
  form = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
    userName: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    confirmPassword: new FormControl('', Validators.required),
    phoneNumber: new FormControl('', Validators.required),
    birthDate: new FormControl(null, Validators.required),
    gender: new FormControl(null, Validators.required),
    marriageStatus: new FormControl(null, Validators.required),
    address: new FormControl('', Validators.required),
    postCode: new FormControl('', Validators.required),
    companyName: new FormControl(''),
    identificationNumberCompany: new FormControl(''),
  });

  ngOnInit(): void {
    this.getGenders();
    this.getMarriageStatuses();
  }

  get formControls() {
    return this.form.controls;
  }
  getGenders() {
    this.enumService.genders().subscribe((data: any) => {
      this.genders = data;
    });
  }

  getMarriageStatuses() {
    this.enumService.marriageStatuses().subscribe((data: any) => {
      this.marriageStatuses = data;
    });
  }

  checkPasswords() {
    let pass = this.form.get('password');
    let confirmPass = this.form.get('confirmPassword');
    if (pass?.value === confirmPass?.value || confirmPass?.value === '') {
      this.differentPass = false;
    } else {
      this.differentPass = true;
    }
  }

  registerClient(data: any) {
    if (this.form.valid) {
      data.birthDate = this.formatter.format(data.birthDate);
      this.clientsService.addClient(data).subscribe(
        (data: any) => {
          this.message = this.t.get('Uspješna registracija');
          this.toastr.success('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
          this.router.navigateByUrl('/auth/login');
        },
        (error) => {
          this.message = this.t.get('Greška prilikom registracije');
          this.toastr.error('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
        }
      );
    }
  }
}
