import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TranslationService } from 'src/app/shared/i18n';
import { IndividualConfig, ToastrService } from 'ngx-toastr';
import { ServicesService } from 'src/app/services/ServicesService';
import { TypeOfServicesService } from 'src/app/services/TypeOfServicesService';

@Component({
  selector: 'app-services-edit',
  templateUrl: './services-edit.component.html',
  styleUrls: ['./services-edit.component.scss'],
})
export class ServicesEditComponent implements OnInit {
  private id: Number;
  sub: any;
  service: any;
  form: FormGroup;
  message: any;
  typeOfServices: any;

  constructor(
    private servicesService: ServicesService,
    private route: ActivatedRoute,
    private router: Router,
    private t: TranslationService,
    private toastr: ToastrService,
    private typeOfServicesService: TypeOfServicesService
  ) {}

  ngOnInit(): void {
    this.sub = this.route.params.subscribe((params) => {
      this.id = +params['id'];
      this.getTypesOfService();
      this.getService();
    });
  }

  loadData(data: any) {
    this.form = new FormGroup({
      id: new FormControl(data.id),
      name: new FormControl(data.name, Validators.required),
      createdAt: new FormControl(data.createdAt, Validators.required),
      typeOfServiceId: new FormControl(
        data.typeOfServiceId,
        Validators.required
      ),
      price1: new FormControl(data.price1, Validators.required),
      price2: new FormControl(data.price2, Validators.required),
      price3: new FormControl(data.price3, Validators.required),
      price4: new FormControl(data.price4, Validators.required),
      price5: new FormControl(data.price5, Validators.required),
      price6: new FormControl(data.price6, Validators.required),
    });
  }

  getService() {
    this.service = this.servicesService
      .getById(this.id)
      .subscribe((data: any) => {
        this.service = data;
        this.loadData(this.service);
      });
  }

  getTypesOfService() {
    this.typeOfServicesService.getAll().subscribe((data: any) => {
      this.typeOfServices = data;
    });
  }

  updateService(data: any) {
    this.servicesService.update(data).subscribe(
      (data) => {
        this.message = this.t.get('SERVICE.EDIT.EDIT_SUCCESS');
        this.toastr.success('', this.message, {
          timeOut: 2500,
          progressBar: true,
          closeButton: true,
        } as IndividualConfig);
        this.router.navigateByUrl('/services');
      },
      (error) => {
        this.message = this.t.get('SERVICE.EDIT.EDIT_ERROR');
        this.toastr.error('', this.message, {
          timeOut: 2500,
          progressBar: true,
          closeButton: true,
        } as IndividualConfig);
      }
    );
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
