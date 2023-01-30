import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { WizardComponent as BaseWizardComponent } from 'angular-archwizard';
import { IndividualConfig, ToastrService } from 'ngx-toastr';
import { CitiesService } from 'src/app/services/CitiesService';
import { CountriesService } from 'src/app/services/CountriesService';
import { EmployeesService } from 'src/app/services/EmployeesService';
import { EnumService } from 'src/app/services/EnumService';
import { TranslationService } from 'src/app/shared/i18n';

@Component({
  selector: 'app-employees-add',
  templateUrl: './employees-add.component.html',
  styleUrls: ['./employees-add.component.scss'],
})
export class EmployeesAddComponent implements OnInit {
  formUserData: FormGroup;
  formJobData: FormGroup;
  genders: any;
  positions: any;
  drivingLicences: any;
  marriageStatuses: any;
  countries: any;
  cities: any;
  citiesFilterList: any;
  message: any;
  imgSrc: any = '../../../assets/images/others/blank-user.jpg';

  isFormUserDataSubmited: Boolean;
  isFormJobDataSubmited: Boolean;

  @ViewChild('wizardForm') wizardForm: BaseWizardComponent;
  constructor(
    public formBuilder: FormBuilder,
    private enumService: EnumService,
    private countriesService: CountriesService,
    private citiesService: CitiesService,
    private formatter: NgbDateParserFormatter,
    private employeesService: EmployeesService,
    private t: TranslationService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getGenders();
    this.getPositions();
    this.getDrivingLicenses();
    this.getMarriageStatuses();
    this.getCountries();
    this.getCities();
    this.formUserData = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      userName: ['', Validators.required],
      email: ['', Validators.required],
      birthDate: [null, Validators.required],
      gender: [null, Validators.required],
      countryId: [null, Validators.required],
      birthPlaceId: [null, Validators.required],
      nationality: ['', Validators.required],
      citizenship: ['', Validators.required],
      profilePhoto: [null],
      file: [null],
    });

    this.formJobData = this.formBuilder.group({
      jmbg: ['', Validators.required],
      marriageStatus: [null, Validators.required],
      qualifications: ['', Validators.required],
      drivingLicence: [null, Validators.required],
      placeOfRecidenceId: [null, Validators.required],
      address: [null, Validators.required],
      postCode: [null, Validators.required],
      phoneNumber: ['', Validators.required],
      dateOfEmployment: [null, Validators.required],
      position: [null, Validators.required],
      pay: ['', Validators.required],
      biography: [''],
    });

    this.isFormUserDataSubmited = false;
    this.isFormJobDataSubmited = false;
  }

  getGenders() {
    this.enumService.genders().subscribe((data: any) => {
      this.genders = data;
    });
  }

  getPositions() {
    this.enumService.positions().subscribe((data: any) => {
      this.positions = data;
    });
  }

  getDrivingLicenses() {
    this.enumService.drivingLicenses().subscribe((data: any) => {
      this.drivingLicences = data;
    });
  }

  getMarriageStatuses() {
    this.enumService.marriageStatuses().subscribe((data: any) => {
      this.marriageStatuses = data;
    });
  }

  getCities() {
    this.citiesService.getAll().subscribe((data: any) => {
      this.cities = data;
      this.citiesFilterList = data;
    });
  }

  getCountries() {
    this.countriesService.getAll().subscribe((data: any) => {
      this.countries = data;
    });
  }

  changeCountry() {
    let countryId = this.formUserData.controls['countryId'].value;
    this.citiesFilterList = this.cities.filter(
      (x: any) => x.countryId == countryId || countryId == null
    );
  }

  finishFunction() {
    if (!this.formUserData.invalid) {
      var formData: FormData = new FormData();

      formData.append('email', this.formUserData.controls['email'].value);
      formData.append('userName', this.formUserData.controls['userName'].value);
      formData.append('file', this.formUserData.controls['file'].value);
      formData.append(
        'firstName',
        this.formUserData.controls['firstName'].value
      );
      formData.append('lastName', this.formUserData.controls['lastName'].value);
      formData.append(
        'birthDate',
        this.formatter.format(this.formUserData.controls['birthDate'].value)
      );
      formData.append('gender', this.formUserData.controls['gender'].value);
      formData.append('profilePhoto', '');
      formData.append('profilePhotoThumbnail', '');
      formData.append(
        'birthPlaceId',
        this.formUserData.controls['birthPlaceId'].value
      );
      formData.append(
        'nationality',
        this.formUserData.controls['nationality'].value
      );
      formData.append(
        'citizenship',
        this.formUserData.controls['citizenship'].value
      );
      formData.append('jmbg', this.formJobData.controls['jmbg'].value);
      formData.append(
        'marriageStatus',
        this.formJobData.controls['marriageStatus'].value
      );
      formData.append(
        'qualifications',
        this.formJobData.controls['qualifications'].value
      );
      formData.append(
        'drivingLicence',
        this.formJobData.controls['drivingLicence'].value
      );
      formData.append(
        'placeOfResidenceId',
        this.formJobData.controls['placeOfRecidenceId'].value
      );
      formData.append('address', this.formJobData.controls['address'].value);
      formData.append('postCode', this.formJobData.controls['postCode'].value);
      formData.append(
        'dateOfEmployment',
        this.formatter.format(
          this.formJobData.controls['dateOfEmployment'].value
        )
      );
      formData.append('pay', this.formJobData.controls['pay'].value);
      formData.append(
        'phoneNumber',
        this.formJobData.controls['phoneNumber'].value
      );
      formData.append(
        'biography',
        this.formJobData.controls['biography'].value
      );
      debugger;
      this.employeesService.addEmployee(formData).subscribe(
        (data: any) => {
          this.message = this.t.get('EMPLOYEE.CREATE.ADD_SUCCESS');
          this.toastr.success('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
          this.router.navigateByUrl('/employees');
        },
        (error) => {
          this.message = this.t.get('EMPLOYEE.CREATE.ADD_ERROR');
          this.toastr.error('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
        }
      );
    }
  }

  get formUserDataControls() {
    return this.formUserData.controls;
  }

  get formJobDataControls() {
    return this.formJobData.controls;
  }

  formUserDataSubmit() {
    if (this.formUserData.valid) {
      this.wizardForm.goToNextStep();
    }
    this.isFormUserDataSubmited = true;
  }

  formJobDataSubmit() {
    if (this.formJobData.valid) {
      this.wizardForm.goToNextStep();
    }
    this.isFormJobDataSubmited = true;
  }

  onFileSelected(event: any) {
    const file = <File>event.target.files[0];
    const reader = new FileReader();
    reader.onload = (e) => (this.imgSrc = reader.result);
    reader.readAsDataURL(file);
    this.formUserData?.controls['file'].setValue(file);
  }
}
