import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IndividualConfig, ToastrService } from 'ngx-toastr';
import { TranslationService } from 'src/app/shared/i18n';
import { CitiesService } from 'src/app/services/CitiesService';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CountriesService } from 'src/app/services/CountriesService';
import { PaginationService } from 'src/app/shared/services/PaginationService';
import { CountriesCitiesSearchObject } from 'src/app/searchObject/CountriesCititesSearchObject';
import { formatDate, getLocaleDateFormat } from '@angular/common';
@Component({
  selector: 'app-news',
  templateUrl: './cities-list.component.html',
  styleUrls: ['./cities-list.component.scss'],
})
export class CitiesListComponent implements OnInit {
  city: any = null;
  cities: any;
  countries: any;
  itemsPerPage: any;
  basicModalCloseResult: string = '';
  currentPage: any = 1;
  pageSize: any;
  collectionSize: any = 0;
  searchCountryId: any;
  search = new CountriesCitiesSearchObject();
  message: string;
  form: FormGroup;
  selectedCountryId: any;

  constructor(
    private citiesService: CitiesService,
    private countriesService: CountriesService,
    private modalService: NgbModal,
    private toastr: ToastrService,
    private t: TranslationService,
    private paginationService: PaginationService
  ) {}

  ngOnInit() {
    this.itemsPerPage = this.paginationService.getItemsPerPage();
    this.pageSize = this.itemsPerPage[0];
    this.getAll();
    this.getCountries();
  }

  openDeleteModal(content: TemplateRef<any>, x: any) {
    this.city = x;
    this.modalService
      .open(content, { centered: true })
      .result.then((result: any) => {
        this.basicModalCloseResult = 'Modal closed' + result;
      })
      .catch((res: any) => console.log(res));
  }

  getCountries() {
    this.countriesService.getAll().subscribe(
      (data: any) => {
        this.countries = data;
      },
      (error: any) => {}
    );
  }

  getAll() {
    if (this.selectedCountryId != null) {
      this.search.countryId = this.selectedCountryId;
    } else {
      this.search.countryId = 0;
    }
    this.citiesService
      .getForPagination(this.search, this.pageSize, this.currentPage)
      .subscribe((data: any) => {
        this.cities = data;
        console.log(this.cities);
        if (this.cities.length > 0) {
          this.collectionSize = this.paginationService.getCollectionSize(
            this.pageSize,
            data[0].totalRecordsCount
          );
        }
      });
  }

  openAddEditModal(content: TemplateRef<any>, data: any) {
    this.city = data;
    this.getCountries();
    if (data != null) {
      this.form = new FormGroup({
        id: new FormControl(data.id),
        createdAt: new FormControl(data.createdAt),
        name: new FormControl(data.name, Validators.required),
        countryId: new FormControl(data.countryId, Validators.required),
        abrv: new FormControl(data.abrv, Validators.required),
        favorite: new FormControl(data.favorite),
      });
    } else {
      this.form = new FormGroup({
        name: new FormControl(null, Validators.required),
        countryId: new FormControl(null, Validators.required),
        abrv: new FormControl(null, Validators.required),
        favorite: new FormControl(false),
      });
    }
    this.modalService
      .open(content, { centered: true })
      .result.then((result: any) => {
        this.basicModalCloseResult = 'Modal closed' + result;
      })
      .catch((res: any) => console.log(res));
  }

  addEditCity(modal: any, data: any) {
    if (data.id != null) {
      this.citiesService.update(data).subscribe(
        (data) => {
          this.message = this.t.get('CITY.EDIT.EDIT_SUCCESS');
          this.toastr.success('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
          this.getAll();
        },
        (error) => {
          this.message = this.t.get('CITY.EDIT.EDIT_ERROR');
          this.toastr.error('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
        }
      );
    } else {
      this.citiesService.post(data).subscribe(
        (data) => {
          this.message = this.t.get('CITY.CREATE.ADD_SUCCESS');
          this.toastr.success('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
          this.getAll();
        },
        (error) => {
          this.message = this.t.get('CITY.CREATE.ADD_ERROR');
          this.toastr.error('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
        }
      );
    }
    modal.close('by: save button');
  }

  deleteService(modal: any) {
    this.citiesService.delete(this.city).subscribe(
      (data: any) => {
        this.getAll();
        this.message = this.t.get('CITY.DELETE.DELETE_SUCCESS');
        this.toastr.success('', this.message, {
          timeOut: 2500,
          progressBar: true,
          closeButton: true,
        } as IndividualConfig);
      },
      (error: any) => {
        this.message = 'CITY.DELETE.DELETE_ERROR';
        this.toastr.error('', this.message, {
          timeOut: 2500,
          progressBar: true,
          closeButton: true,
        } as IndividualConfig);
      }
    );
    modal.close('by: save button');
  }

  get name() {
    return this.form.get('name');
  }

  get abrv() {
    return this.form.get('abrv');
  }

  get countryId() {
    return this.form.get('countryId');
  }
}
