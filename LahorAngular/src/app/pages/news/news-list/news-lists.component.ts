import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { NewsService } from '../../../services/NewsService';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IndividualConfig, ToastrService } from 'ngx-toastr';
import { TranslationService } from 'src/app/shared/i18n';
import { PaginationService } from 'src/app/shared/services/PaginationService';
import { BaseSearchObject } from 'src/app/searchObject/BaseSearchObject';
import { AuthAdminGuard } from 'src/app/core/guard/authAdmin.guard';
import { AuthCompanyOwnerGuard } from 'src/app/core/guard/authCompanyOwner.guard';

@Component({
  selector: 'app-news',
  templateUrl: './news-lists.component.html',
  styleUrls: ['./news-lists.component.scss'],
})
export class NewsListsComponent implements OnInit {
  news: any;
  selectedNew: any = null;
  basicModalCloseResult: string = '';
  message: string;
  currentPage: any = 1;
  pageSize: any = 5;
  collectionSize: any = 20;
  search = new BaseSearchObject();
  itemsPerPage: any;

  constructor(
    private newsService: NewsService,
    private router: Router,
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

  openBasicModal(content: TemplateRef<any>, x: any) {
    this.selectedNew = x;
    this.modalService
      .open(content, {})
      .result.then((result: any) => {
        this.basicModalCloseResult = 'Modal closed' + result;
      })
      .catch((res: any) => console.log(res));
  }

  getAll() {
    this.newsService
      .getForPagination(this.search, this.pageSize, this.currentPage)
      .subscribe((data: any) => {
        this.news = data;
        if (data != null) {
          this.collectionSize = this.paginationService.getCollectionSize(
            this.pageSize,
            data[0]?.totalRecordsCount
          );
        }
      });
  }

  addNew() {
    this.router.navigateByUrl('/news/news-add');
  }

  editNew(x: any) {
    this.router.navigate(['/news/news-edit', x.id]);
  }

  previewNew(x: any) {
    this.router.navigate(['/news/news-preview', x.id]);
  }

  get isAdmin() {
    return AuthAdminGuard.isActive();
  }

  get isCompanyOwner() {
    return AuthCompanyOwnerGuard.isActive();
  }

  async deleteNew(modal: any) {
    this.newsService.delete(this.selectedNew).subscribe(
      (data: any) => {
        this.getAll();
        this.message = this.t.get('NEW.DELETE_SUCCESS');
        this.toastr.success('', this.message, {
          timeOut: 2500,
          progressBar: true,
          closeButton: true,
        } as IndividualConfig);
      },
      (error: any) => {
        this.message = 'NEW.DELETE_ERROR';
        this.toastr.error('', this.message, {
          timeOut: 2500,
          progressBar: true,
          closeButton: true,
        } as IndividualConfig);
      }
    );

    modal.close('by: save button');
  }

  changePage() {
    this.getAll();
  }
}
