import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IndividualConfig, ToastrService } from 'ngx-toastr';
import { CitiesService } from 'src/app/services/CitiesService';
import { CountriesService } from 'src/app/services/CountriesService';
import { EmployeesService } from 'src/app/services/EmployeesService';
import { EnumService } from 'src/app/services/EnumService';
import { TranslationService } from 'src/app/shared/i18n';
import { MyConfig } from 'src/app/shared/MyConfig';
import { NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-employees-edit',
  templateUrl: './employees-edit.component.html',
  styleUrls: ['./employees-edit.component.scss'],
})
export class EmployeesEditComponent implements OnInit {
  private id: Number;
  formUserData: FormGroup;
  formJobData: FormGroup;
  sub: any;
  employee: any;
  imgUrl: any = '../../../assets/images/others/blank-user.jpg';
  message: any;
  isFormUserDataSubmited: boolean = false;
  isFormJobDataSubmited: boolean = false;
  isEmployee: boolean = false;
  genders: any;
  cities: any;
  countries: any;
  citiesFilterList: any;
  positions: any;
  drivingLicences: any;
  marriageStatuses: any;

  constructor(
    private employeesService: EmployeesService,
    private route: ActivatedRoute,
    private router: Router,
    private t: TranslationService,
    private toastr: ToastrService,
    private enumService: EnumService,
    private citiesService: CitiesService,
    private countriesService: CountriesService,
    private formatter: NgbDateParserFormatter
  ) {}

  ngOnInit(): void {
    this.sub = this.route.params.subscribe((params) => {
      this.id = +params['id'];
      this.getGenders();
      this.getPositions();
      this.getMarriageStatuses();
      this.getDrivingLicenses();
      this.getCities();
      this.getCountries();
      this.getEmployee();
    });
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

  getEmployee() {
    this.employeesService.getById(this.id).subscribe((data: any) => {
      this.employee = data;
      console.log(this.employee);
      this.loadData(this.employee);
      this.createImageUrl(this.employee.person.profilePhoto);
    });
  }

  loadData(data: any) {
    this.formUserData = new FormGroup({
      firstName: new FormControl(data.person.firstName, Validators.required),
      lastName: new FormControl(data.person.lastName, Validators.required),
      userName: new FormControl(data.userName, Validators.required),
      email: new FormControl(data.email, Validators.required),
      birthDate: new FormControl(
        this.formatter.parse(data.person.birthDate),
        Validators.required
      ),
      gender: new FormControl(data.person.gender, Validators.required),
      birthPlaceId: new FormControl(
        data.person.birthPlaceId,
        Validators.required
      ),
      nationality: new FormControl(
        data.person.nationality,
        Validators.required
      ),
      citizenship: new FormControl(
        data.person.citizenship,
        Validators.required
      ),
      file: new FormControl(null),
      countryId: new FormControl(data.person.birthPlace.countryId),
    });

    this.formJobData = new FormGroup({
      jmbg: new FormControl(data.person.jmbg, Validators.required),
      marriageStatus: new FormControl(
        data.person.marriageStatus,
        Validators.required
      ),
      qualifications: new FormControl(data.person.qualifications),
      drivingLicence: new FormControl(
        data.person.drivingLicence,
        Validators.required
      ),
      dateOfEmployment: new FormControl(
        this.formatter.parse(data.person.dateOfEmployment),
        Validators.required
      ),
      placeOfRecidenceId: new FormControl(
        data.person.placeOfResidenceId,
        Validators.required
      ),
      countryId: new FormControl(data.person.placeOfResidence.countryId),
      address: new FormControl(data.person.address, Validators.required),
      postCode: new FormControl(data.person.postCode, Validators.required),
      position: new FormControl(data.person.position, Validators.required),
      pay: new FormControl(data.person.pay, Validators.required),
      phoneNumber: new FormControl(data.phoneNumber, Validators.required),
      biography: new FormControl(data.person.biography),
    });
  }

  get formUserDataControls() {
    return this.formUserData.controls;
  }

  get formJobDataControls() {
    return this.formJobData.controls;
  }

  public createImageUrl = (imgSrc: any) => {
    if (imgSrc != null) {
      this.imgUrl = MyConfig.address_server_base + imgSrc;
    }
  };

  onFileSelected(event: any) {
    const file = <File>event.target.files[0];
    const reader = new FileReader();
    reader.onload = (e) => (this.imgUrl = reader.result);
    reader.readAsDataURL(file);
    this.formUserData?.controls['file'].setValue(file);
  }

  deactivate() {
    this.employeesService.deactivate(this.id).subscribe(
      (data: any) => {
        this.message = this.t.get(data.success.text.toString());
        this.toastr.success('', this.message, {
          timeOut: 2500,
          progressBar: true,
          closeButton: true,
        } as IndividualConfig);
        this.router.navigateByUrl('/employees');
      },
      (error) => {
        this.message = this.t.get(error.error.text.toString());
        if (error.status === 200) {
          this.toastr.success('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
          this.router.navigateByUrl('/employees');
        } else {
          this.message = this.t.get('SHARED.DEACTIVATE_ERROR');
          this.toastr.error('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
        }
      }
    );
  }

  editEmployee() {
    if (this.formUserData.valid && this.formJobData.valid) {
      var formData: FormData = new FormData();
      formData.append('id', this.id.toString());
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
      formData.append('profilePhoto', this.employee.person.profilePhoto);
      formData.append(
        'profilePhotoThumbnail',
        this.employee.person.profilePhotoThumbnail
      );
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
      formData.append('position', this.formJobData.controls['position'].value);
      formData.append(
        'phoneNumber',
        this.formJobData.controls['phoneNumber'].value
      );
      formData.append('pay', this.formJobData.controls['pay'].value);
      formData.append(
        'biography',
        this.formJobData.controls['biography'].value
      );
      this.employeesService.editEmployee(formData).subscribe(
        (data: any) => {
          this.message = this.t.get('EMPLOYEE.EDIT.EDIT_SUCCESS');
          this.toastr.success('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
          this.router.navigateByUrl('/employees');
        },
        (error) => {
          this.message = this.t.get('EMPLOYEE.EDIT.EDIT_ERROR');
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
