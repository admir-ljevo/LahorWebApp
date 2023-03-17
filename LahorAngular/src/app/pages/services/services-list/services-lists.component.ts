import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ServicesService } from '../../../services/ServicesService';
import { IndividualConfig, ToastrService } from 'ngx-toastr';
import { TranslationService } from 'src/app/shared/i18n';
import { PaginationService } from 'src/app/shared/services/PaginationService';
import { ServicesSearchObject } from 'src/app/searchObject/ServicesSearchObject';
import { TypeOfServicesService } from 'src/app/services/TypeOfServicesService';
import { BaseSearchObject } from 'src/app/searchObject/BaseSearchObject';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthAdminGuard } from 'src/app/core/guard/authAdmin.guard';
import { AuthCompanyOwnerGuard } from 'src/app/core/guard/authCompanyOwner.guard';
@Component({
  selector: 'app-news',
  templateUrl: './services-lists.component.html',
  styleUrls: ['./services-lists.component.scss'],
})
export class ServicesListsComponent implements OnInit {
  selectedService: any = null;
  services: any;
  basicModalCloseResult: string = '';
  currentPage: any = 1;
  pageSize: any;
  collectionSize: any = 20;
  currentPageTypeOfServices: any = 1;
  pageSizeTypeOfServices: any;
  collectionSizeTypeOfServices: any = 20;
  search = new ServicesSearchObject();
  baseSearch = new BaseSearchObject();
  message: string;
  itemsPerPage: any;
  typeOfServicesDropDown: any;
  selectedTypeOfServiceId: any;
  typeOfServices: any;
  typeOfServiceAddEdit: any;
  form: any;

  constructor(
    private servicesService: ServicesService,
    private typeOfServicesService: TypeOfServicesService,
    private router: Router,
    private modalService: NgbModal,
    private toastr: ToastrService,
    private t: TranslationService,
    private paginationService: PaginationService
  ) {}

  ngOnInit() {
    this.itemsPerPage = this.paginationService.getItemsPerPage();
    this.pageSize = this.itemsPerPage[0];
    this.pageSizeTypeOfServices = this.itemsPerPage[0];
    this.getAll();
    this.getTypesOfServiceDropDown();
    this.getTypeOfServices();
  }

  openBasicModal(content: TemplateRef<any>, x: any) {
    this.selectedService = x;
    this.modalService
      .open(content, {})
      .result.then((result: any) => {
        this.basicModalCloseResult = 'Modal closed' + result;
      })
      .catch((res: any) => console.log(res));
  }

  getAll() {
    if (this.selectedTypeOfServiceId != null) {
      this.search.typeOfServiceId = this.selectedTypeOfServiceId;
    } else {
      this.search.typeOfServiceId = 0;
    }
    this.servicesService
      .getForPagination(this.search, this.pageSize, this.currentPage)
      .subscribe((data: any) => {
        this.services = data;
        if (this.services.length > 0) {
          this.collectionSize = this.paginationService.getCollectionSize(
            this.pageSize,
            data[0].totalRecordsCount
          );
        }
      });
  }

  getTypesOfServiceDropDown() {
    this.typeOfServicesService.getAll().subscribe((data: any) => {
      this.typeOfServicesDropDown = data;
    });
  }

  getTypeOfServices() {
    this.typeOfServicesService
      .getForPagination(
        this.baseSearch,
        this.pageSizeTypeOfServices,
        this.currentPageTypeOfServices
      )
      .subscribe((data: any) => {
        this.typeOfServices = data;
        if (this.typeOfServices.length > 0) {
          this.collectionSizeTypeOfServices =
            this.paginationService.getCollectionSize(
              this.pageSizeTypeOfServices,
              data[0].totalRecordsCount
            );
        }
      });
  }

  addService() {
    this.router.navigateByUrl('/services/services-add');
  }

  editService(x: any) {
    this.router.navigate(['/services/services-edit', x.id]);
  }

  deleteService(modal: any) {
    this.servicesService.delete(this.selectedService).subscribe(
      (data: any) => {
        this.getAll();
        this.message = this.t.get('SERVICE.DELETE.DELETE_SUCCESS');
        this.toastr.success('', this.message, {
          timeOut: 2500,
          progressBar: true,
          closeButton: true,
        } as IndividualConfig);
      },
      (error: any) => {
        this.message = 'SERVICE.DELETE.DELETE_ERROR';
        this.toastr.error('', this.message, {
          timeOut: 2500,
          progressBar: true,
          closeButton: true,
        } as IndividualConfig);
      }
    );
    modal.close('by: save button');
  }

  openAddEditModalTypeOfService(content: TemplateRef<any>, data: any) {
    this.typeOfServiceAddEdit = data;
    if (data != null) {
      this.form = new FormGroup({
        id: new FormControl(data.id),
        createdAt: new FormControl(data.createdAt),
        name: new FormControl(data.name, Validators.required),
      });
    } else {
      this.form = new FormGroup({
        name: new FormControl(null, Validators.required),
      });
    }
    this.modalService
      .open(content, { centered: true })
      .result.then((result: any) => {
        this.basicModalCloseResult = 'Modal closed' + result;
      })
      .catch((res: any) => console.log(res));
  }

  addEditTypeOfService(modal: any, data: any) {
    if (data.id != null) {
      this.typeOfServicesService.update(data).subscribe(
        (data) => {
          this.message = this.t.get('TYPE_OF_SERVICE.EDIT.EDIT_SUCCESS');
          this.toastr.success('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
          this.getTypeOfServices();
        },
        (error) => {
          this.message = this.t.get('TYPE_OF_SERVICE.EDIT.EDIT_ERROR');
          this.toastr.error('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
        }
      );
    } else {
      this.typeOfServicesService.post(data).subscribe(
        (data) => {
          this.message = this.t.get('TYPE_OF_SERVICE.CREATE.ADD_SUCCESS');
          this.toastr.success('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
          this.getTypeOfServices();
        },
        (error) => {
          this.message = this.t.get('TYPE_OF_SERVICE.CREATE.ADD_ERROR');
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

  get name() {
    return this.form.get('name');
  }

  openDeleteModalTypeOfService(content: TemplateRef<any>, x: any) {
    this.typeOfServiceAddEdit = x;
    this.modalService
      .open(content, { centered: true })
      .result.then((result: any) => {
        this.basicModalCloseResult = 'Modal closed' + result;
      })
      .catch((res: any) => console.log(res));
  }

  deleteTypeOfService(modal: any) {
    this.typeOfServicesService.delete(this.typeOfServiceAddEdit).subscribe(
      (data: any) => {
        this.getTypeOfServices();
        this.message = this.t.get('TYPE_OF_SERVICE.DELETE.DELETE_SUCCESS');
        this.toastr.success('', this.message, {
          timeOut: 2500,
          progressBar: true,
          closeButton: true,
        } as IndividualConfig);
      },
      (error: any) => {
        this.message = 'TYPE_OF_SERVICE.DELETE.DELETE_ERROR';
        this.toastr.error('', this.message, {
          timeOut: 2500,
          progressBar: true,
          closeButton: true,
        } as IndividualConfig);
      }
    );
    modal.close('by: save button');
  }

  get isAdmin() {
    return AuthAdminGuard.isActive();
  }

  get isCompanyOwner() {
    return AuthCompanyOwnerGuard.isActive();
  }
}
