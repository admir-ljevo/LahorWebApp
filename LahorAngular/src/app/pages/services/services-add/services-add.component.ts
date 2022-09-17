import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {ServiceModel} from "../../../models/service-model";
import {ServicesService} from "../../../services/ServicesService";
import {TypeOfServicesService} from "../../../services/TypeOfServicesService";
import {Observable} from "rxjs";

@Component({
  selector: 'app-services-add',
  templateUrl: './services-add.component.html',
  styleUrls: ['./services-add.component.scss']
})
export class ServicesAddComponent implements OnInit {

  new:ServiceModel=new ServiceModel();
  typeOfServices$!:Observable<any[]>;
  typeOfServices:any;
  selectedSearchTypeOfServiceId:Number;

  constructor(private servicesService:ServicesService,private typeOfServicesService:TypeOfServicesService, private router:Router) { }

  ngOnInit(): void {
    this.getTypesOfService();
  }

  addNew(){
    this.new.typeOfServiceId=this.selectedSearchTypeOfServiceId;
      this.servicesService.post(this.new).subscribe(data=>{
        this.router.navigateByUrl("/services");
      })
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
    this.selectedSearchTypeOfServiceId=type.id;
  }


}
