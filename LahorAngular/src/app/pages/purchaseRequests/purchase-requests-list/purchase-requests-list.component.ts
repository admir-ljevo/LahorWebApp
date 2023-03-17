import {Component, OnInit, TemplateRef} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {PurchaseRequestService} from "../../../services/PurchaseRequestService";
import {Observable} from "rxjs";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-purchase-requests-list',
  templateUrl: './purchase-requests-list.component.html',
  styleUrls: ['./purchase-requests-list.component.scss']
})
export class PurchaseRequestsListComponent implements OnInit {

  constructor(private modalService: NgbModal,
              private router: Router,
              private purchaseRequestService: PurchaseRequestService) { }
  purchaseRequests$: Observable<any[]>;
  purchaseRequests: any[];

  selectedRequest: any = null;
  currentPage: number = 1;
  oldCurrentPage: number = this.currentPage;
  pageSize: number = 2;
  collectionSize: any = 20;
  searchFilter: string = '';
  basicModalCloseResult: string = '';
  ngOnInit(): void {
    this.getAllRequests();
  }

  getAllRequests(): void {
 this.purchaseRequestService.getForPagination(this.searchFilter, this.pageSize, this.currentPage).subscribe(data=>{
  this.purchaseRequests=data;
  if(this.currentPage>(this.collectionSize/10)-1 && this.purchaseRequests.length==this.pageSize)
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

  changePage(){
    this.getAllRequests();
  }

  addPurchaseRequest(): void {
    this.router.navigateByUrl('/purchase-requests/add-purchase-request');
  }

  openBasicModal(content: TemplateRef<any>,x:any){
    this.selectedRequest = x;
    this.modalService.open(content, {}).result.then((result:any) => {
      this.basicModalCloseResult = "Modal closed" + result
    }).catch((res:any)=>console.log(res));
  }

  deleteRequest(modal: any) {
    this.purchaseRequestService.delete(this.selectedRequest).subscribe(data=> {
      this.getAllRequests()
    });
    modal.close('by: save button');
  }

  editRequest(id: number){
    this.router.navigate(['purchase-requests/edit-purchase-request', id]);
  }

  openMaterialRequests(id: number){
     this.router.navigate(['material-requests', id]);
  }

}
