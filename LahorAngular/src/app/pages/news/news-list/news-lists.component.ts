import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { NewsService } from 'src/app/services/NewsService';

@Component({
  selector: 'app-news',
  templateUrl: './news-lists.component.html',
  styleUrls: ['./news-lists.component.scss']
})
export class NewsListsComponent implements OnInit {

  news$!:Observable<any[]>;
  selectedNew:any=null;
  constructor(private newsService:NewsService,private httpClient:HttpClient,private router:Router) { }

  ngOnInit() {
     this.news$=this.newsService.getAll();
      this.news$.subscribe(data=>{
        console.log(data);
      });
  }

  editNew(x:any)
  {
    this.router.navigate(['/news-edit',x.id]);
  }

  addNew()
  {
    debugger;
    this.router.navigateByUrl("/news-add");
  }

}
