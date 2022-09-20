import {Component, OnInit, TemplateRef} from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {ServicesService} from "../../../services/ServicesService";
import {DataTable} from "simple-datatables";

@Component({
  selector: 'app-news',
  templateUrl: './services-lists.component.html',
  styleUrls: ['./services-lists.component.scss']
})
export class ServicesListsComponent implements OnInit {

  services$!:Observable<any[]>;
  selectedService:any=null;
  services:any;
  basicModalCloseResult:string='';
  currentPage:any=1;
  oldCurrentPage:any=this.currentPage;
  pageSize:any=2;
  collectionSize:any=20;
  searchFilter:string="";
  constructor(private servicesService:ServicesService,private router:Router,private modalService:NgbModal) {

  }

  ngOnInit() {
     this.getAll();
  }

  changePage()
  {
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
    // this.services$=this.servicesService.getAll();
    // this.services$.subscribe((data:any)=>{
    //   this.services=data;
    // });
    this.servicesService.getForPagination(this.searchFilter,this.pageSize,this.currentPage).subscribe((data:any)=>{
      this.services=data;
      if(this.currentPage>(this.collectionSize/10)-1 && this.services.length==this.pageSize)
      {
        this.oldCurrentPage=this.currentPage;
        this.collectionSize=(this.currentPage+1)*10;
      }
      if(this.oldCurrentPage>this.currentPage)
      {
        this.collectionSize=this.collectionSize-10;
      }
    });
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
