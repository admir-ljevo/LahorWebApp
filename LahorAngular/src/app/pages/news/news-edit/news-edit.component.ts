import { Component, OnInit } from '@angular/core';
import {NewsService} from "../../../services/NewsService";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-services-edit',
  templateUrl: './news-edit.component.html',
  styleUrls: ['./news-edit.component.scss']
})
export class NewsEditComponent implements OnInit {

  sub:any;
  private id:Number;
  new:any;
  constructor(private newsService:NewsService,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params=>{
      this.id=+params['id'];
      this.getNew();
    });
  }

  onChanged($event:any) {
    this.new.public = $event && $event.target && $event.target.checked;
  }

  getNew()
  {
    this.new=this.newsService.getById(this.id).subscribe((data:any)=>{
      this.new=data;
    });
  }

  updateNew()
  {
    this.newsService.update(this.new);
    this.router.navigateByUrl("/news");
  }

}
