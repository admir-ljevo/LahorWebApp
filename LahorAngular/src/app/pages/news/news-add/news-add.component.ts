import { Component, OnInit } from '@angular/core';
import {NewModel} from "../../../models/new-model";
import {NewsService} from "../../../services/NewsService";
import {Router} from "@angular/router";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MyConfig} from "../../../shared/MyConfig";
import {FormControl, FormGroup, Validator, Validators} from "@angular/forms";

@Component({
  selector: 'app-services-add',
  templateUrl: './news-add.component.html',
  styleUrls: ['./news-add.component.scss']
})
export class NewsAddComponent implements OnInit {

  new:NewModel=new NewModel();
  myForm=new FormGroup({
    name:new FormControl(''),
    text:new FormControl(''),
    file:new FormControl(''),
    public:new FormControl(''),
    userId:new FormControl(1),
    image:new FormControl(null)
  });

  constructor(private newsService:NewsService,private router:Router,private httpClient:HttpClient) {
  }

  ngOnInit(): void {
  }

  addNew(){
    this.myForm.controls['userId'].setValue(1);
    const formData:FormData = new FormData();
    formData.append('name', this.myForm.controls['name'].value);
    formData.append('text', this.myForm.controls['text'].value);
    formData.append('userId', this.myForm.controls['userId'].value);
    formData.append("file", this.myForm.controls['file'].value);
    formData.append('public', this.myForm.controls['public'].value);
    formData.append('image', "");

    this.newsService.addNewWithPhoto(formData);
  }


  onFileSelected(event:any)
  {
    let file=<File>event.target.files[0];
    this.myForm.controls['file'].setValue(file);
  }

  onChanged($event:any) {
    this.new.public = $event && $event.target && $event.target.checked;
  }

}
