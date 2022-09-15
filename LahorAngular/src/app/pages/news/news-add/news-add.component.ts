import { Component, OnInit } from '@angular/core';
import {NewModel} from "../../../models/new-model";
import {NewsService} from "../../../services/NewsService";
import {Router} from "@angular/router";

@Component({
  selector: 'app-news-add',
  templateUrl: './news-add.component.html',
  styleUrls: ['./news-add.component.scss']
})
export class NewsAddComponent implements OnInit {

  new:NewModel=new NewModel();

  constructor(private newsService:NewsService,private router:Router) { }

  ngOnInit(): void {
  }

  addNew(){
      this.newsService.post(this.new).subscribe(data=>{
        console.log(data);
        this.router.navigateByUrl("/news");
      })
  }

  onChanged($event:any) {
    this.new.public = $event && $event.target && $event.target.checked;
  }

}
