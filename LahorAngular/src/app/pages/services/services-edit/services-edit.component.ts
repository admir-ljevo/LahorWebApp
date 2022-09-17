import { Component, OnInit } from '@angular/core';
import {NewsService} from "../../../services/NewsService";
import {ActivatedRoute, Router} from "@angular/router";
import {ServicesService} from "../../../services/ServicesService";
import {TypeOfServicesService} from "../../../services/TypeOfServicesService";
import {Observable} from "rxjs";

@Component({
  selector: 'app-services-edit',
  templateUrl: './services-edit.component.html',
  styleUrls: ['./services-edit.component.scss']
})
export class ServicesEditComponent implements OnInit {

  sub:any;
  private id:Number;
  service:any;
  typeOfServices$!:Observable<any[]>;
  typeOfServices:any;
  selectedSearchTypeOfServiceId:Number;

  constructor(private servicesService:ServicesService,public typeOfServicesService:TypeOfServicesService,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params=>{
      this.id=+params['id'];
      this.getNew();
    });
  }

  getNew()
  {
    this.service=this.servicesService.getById(this.id).subscribe((data:any)=>{
      this.service=data;
      this.selectedSearchTypeOfServiceId=this.service.typeOfServiceId;
      this.getTypesOfService();
    });
  }

  getTypesOfService()
  {
    this.typeOfServices$=this.typeOfServicesService.getAll();
    this.typeOfServices$.subscribe((data:any)=>{
      this.typeOfServices=data;
    });
  }

  changeTypeOfService(type:any)
  {
    this.service.typeOfServiceId=type.id;
  }

  updateService()
  {
    this.servicesService.update(this.service);
    this.router.navigateByUrl("/services");
  }

}
