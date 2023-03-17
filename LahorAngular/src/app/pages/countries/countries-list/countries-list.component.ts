import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IndividualConfig, ToastrService } from 'ngx-toastr';
import { TranslationService } from 'src/app/shared/i18n';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CountriesService } from 'src/app/services/CountriesService';
import { PaginationService } from 'src/app/shared/services/PaginationService';
import { BaseSearchObject } from 'src/app/searchObject/BaseSearchObject';
@Component({
  selector: 'app-news',
  templateUrl: './countries-list.component.html',
  styleUrls: ['./countries-list.component.scss'],
})
export class CountriesListComponent implements OnInit {
  country: any;
  countries: any;
  basicModalCloseResult: string = '';
  itemsPerPage: any;
  currentPage: any = 1;
  pageSize: any;
  collectionSize: any = 0;
  search = new BaseSearchObject();
  message: string;
  form: FormGroup;

  constructor(
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
  }

  openDeleteModal(content: TemplateRef<any>, x: any) {
    this.country = x;
    this.modalService
      .open(content, {})
      .result.then((result: any) => {
        this.basicModalCloseResult = 'Modal closed' + result;
      })
      .catch((res: any) => console.log(res));
  }

  getAll() {
    this.countriesService
      .getForPagination(this.search, this.pageSize, this.currentPage)
      .subscribe((data: any) => {
        this.countries = data;
        if (this.countries.length > 0) {
          this.collectionSize = this.paginationService.getCollectionSize(
            this.pageSize,
            data[0].totalRecordsCount
          );
        }
      });
  }

  openAddEditModal(content: TemplateRef<any>, data: any) {
    this.country = data;
    if (data != null) {
      this.form = new FormGroup({
        id: new FormControl(data.id),
        createdAt: new FormControl(data.createdAt),
        name: new FormControl(data.name, Validators.required),
        abrv: new FormControl(data.abrv, Validators.required),
        favorite: new FormControl(data.favorite),
      });
    } else {
      this.form = new FormGroup({
        name: new FormControl(null, Validators.required),
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

  addEditCountry(modal: any, data: any) {
    if (data.id != null) {
      this.countriesService.update(data).subscribe(
        (data) => {
          this.message = this.t.get('COUNTRY.EDIT.EDIT_SUCCESS');
          this.toastr.success('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
          this.getAll();
        },
        (error) => {
          this.message = this.t.get('COUNTRY.EDIT.EDIT_ERROR');
          this.toastr.error('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
        }
      );
    } else {
      this.countriesService.post(data).subscribe(
        (data) => {
          this.message = this.t.get('COUNTRY.CREATE.ADD_SUCCESS');
          this.toastr.success('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
          this.getAll();
        },
        (error) => {
          this.message = this.t.get('COUNTRY.CREATE.ADD_ERROR');
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

  deleteCountry(modal: any) {
    this.countriesService.delete(this.country).subscribe(
      (data: any) => {
        this.getAll();
        this.message = this.t.get('COUNTRY.DELETE.DELETE_SUCCESS');
        this.toastr.success('', this.message, {
          timeOut: 2500,
          progressBar: true,
          closeButton: true,
        } as IndividualConfig);
      },
      (error: any) => {
        this.message = 'COUNTRY.DELETE.DELETE_ERROR';
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
