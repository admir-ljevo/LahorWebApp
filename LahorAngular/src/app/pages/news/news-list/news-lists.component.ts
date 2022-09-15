import {Component, OnInit, TemplateRef} from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import {NewsService} from "../../../services/NewsService";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-news',
  templateUrl: './news-lists.component.html',
  styleUrls: ['./news-lists.component.scss']
})
export class NewsListsComponent implements OnInit {

  news$!:Observable<any[]>;
  selectedNew:any=null;
  basicModalCloseResult:string='';
  constructor(private newsService:NewsService,private router:Router,private modalService:NgbModal) { }

  ngOnInit() {
     this.getAll();
  }

  openBasicModal(content: TemplateRef<any>,x:any) {
    this.selectedNew=x;
    this.modalService.open(content, {}).result.then((result:any) => {
      this.basicModalCloseResult = "Modal closed" + result
    }).catch((res:any)=>console.log(res));
  }

  getAll()
  {
    this.news$=this.newsService.getAll();
  }

  addNew()
  {
    this.router.navigateByUrl("/news/news-add");
  }

  editNew(x:any)
  {
    this.router.navigate(['/news/news-edit',x.id]);
  }

  deleteNew(modal:any)
  {
    this.newsService.delete(this.selectedNew).subscribe(data=>{
      this.getAll();
    })
    modal.close('by: save button');
  }

}
