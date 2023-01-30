import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceModel } from '../../../models/service-model';
import { ServicesService } from '../../../services/ServicesService';
import { TypeOfServicesService } from '../../../services/TypeOfServicesService';
import { Observable } from 'rxjs';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IndividualConfig, ToastrService } from 'ngx-toastr';
import { TranslationService } from 'src/app/shared/i18n';

@Component({
  selector: 'app-services-add',
  templateUrl: './services-add.component.html',
  styleUrls: ['./services-add.component.scss'],
})
export class ServicesAddComponent implements OnInit {
  service: ServiceModel = new ServiceModel();
  typeOfServices: any;
  message: string;
  form = new FormGroup({
    name: new FormControl('', Validators.required),
    typeOfServiceId: new FormControl(null, Validators.required),
    price1: new FormControl(null, Validators.required),
    price2: new FormControl(null, Validators.required),
    price3: new FormControl(null, Validators.required),
    price4: new FormControl(null, Validators.required),
    price5: new FormControl(null, Validators.required),
    price6: new FormControl(null, Validators.required),
  });

  constructor(
    private servicesService: ServicesService,
    private typeOfServicesService: TypeOfServicesService,
    private router: Router,
    private toastr: ToastrService,
    private t: TranslationService
  ) {}

  ngOnInit(): void {
    this.getTypesOfService();
  }

  addService(data: any) {
    if (this.form.valid) {
      this.servicesService.post(data).subscribe(
        (data: any) => {
          this.message = this.t.get('SERVICE.CREATE.ADD_SUCCESS');
          this.toastr.success('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
          this.router.navigateByUrl('/services');
        },
        (error) => {
          this.message = this.t.get('SERVICE.CREATE.ADD_ERROR');
          this.toastr.error('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
        }
      );
    }
  }

  getTypesOfService() {
    this.typeOfServicesService.getAll().subscribe((data: any) => {
      this.typeOfServices = data;
    });
  }

  get name() {
    return this.form.get('name');
  }

  get typeOfServiceId() {
    return this.form.get('typeOfServiceId');
  }

  get price1() {
    return this.form.get('price1');
  }

  get price2() {
    return this.form.get('price2');
  }

  get price3() {
    return this.form.get('price3');
  }

  get price4() {
    return this.form.get('price4');
  }

  get price5() {
    return this.form.get('price5');
  }

  get price6() {
    return this.form.get('price6');
  }
}
