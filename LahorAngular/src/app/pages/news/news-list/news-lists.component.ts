import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { NewsService } from '../../../services/NewsService';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IndividualConfig, ToastrService } from 'ngx-toastr';
import { TranslationService } from 'src/app/shared/i18n';

@Component({
  selector: 'app-news',
  templateUrl: './news-lists.component.html',
  styleUrls: ['./news-lists.component.scss'],
})
export class NewsListsComponent implements OnInit {
  news$!: Observable<any[]>;
  selectedNew: any = null;
  basicModalCloseResult: string = '';
  message: string;
  constructor(
    private newsService: NewsService,
    private router: Router,
    private modalService: NgbModal,
    private toastr: ToastrService,
    private t: TranslationService
  ) {}

  ngOnInit() {
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
    this.news$ = this.newsService.getAll();
  }

  addNew() {
    this.router.navigateByUrl('/news/services-add');
  }

  editNew(x: any) {
    this.router.navigate(['/news/services-edit', x.id]);
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
}
