import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NewsService } from 'src/app/services/NewsService';
import { TranslationService } from 'src/app/shared/i18n';
import { MyConfig } from 'src/app/shared/MyConfig';

@Component({
  selector: 'app-news-preview',
  templateUrl: './news-preview.component.html',
  styleUrls: ['./news-preview.component.scss'],
})
export class NewsPreviewComponent implements OnInit {
  private id: Number;
  sub: any;
  new: any;
  imgUrl: any = '../../../assets/images/others/default_new.webp';
  message: any;
  newName: any;

  constructor(
    private newsService: NewsService,
    private route: ActivatedRoute,
    private router: Router,
    private t: TranslationService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.sub = this.route.params.subscribe((params) => {
      this.id = +params['id'];
      this.getNew();
    });
  }

  getNew() {
    this.new = this.newsService.getById(this.id).subscribe((data: any) => {
      this.new = data;
      this.newName = data.name;
      console.log(this.new);
      this.createImageUrl(this.new.image);
    });
  }

  public createImageUrl = (imgSrc: string) => {
    if (imgSrc != null) {
      this.imgUrl = MyConfig.address_server_base + imgSrc;
    }
  };
}
