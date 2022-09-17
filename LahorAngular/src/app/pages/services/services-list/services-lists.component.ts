import {Component, OnInit, TemplateRef} from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {ServicesService} from "../../../services/ServicesService";

@Component({
  selector: 'app-news',
  templateUrl: './services-lists.component.html',
  styleUrls: ['./services-lists.component.scss']
})
export class ServicesListsComponent implements OnInit {

  services$!:Observable<any[]>;
  selectedService:any=null;
  basicModalCloseResult:string='';
  constructor(private servicesService:ServicesService,private router:Router,private modalService:NgbModal) { }

  ngOnInit() {
     this.getAll();
  }

  openBasicModal(content: TemplateRef<any>,x:any) {
    this.selectedService=x;
    this.modalService.open(content, {}).result.then((result:any) => {
      this.basicModalCloseResult = "Modal closed" + result
    }).catch((res:any)=>console.log(res));
  }

  getAll()
  {
    this.services$=this.servicesService.getAll();
  }

  addService()
  {
    this.router.navigateByUrl("/services/services-add");
  }

  editService(x:any)
  {
    this.router.navigate(['/services/services-edit',x.id]);
  }

  deleteService(modal:any)
  {
    this.servicesService.delete(this.selectedService).subscribe(data=>{
      this.getAll();
    })
    modal.close('by: save button');
  }

}
