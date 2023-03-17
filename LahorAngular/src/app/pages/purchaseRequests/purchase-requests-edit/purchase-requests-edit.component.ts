import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {PurchaseRequestService} from "../../../services/PurchaseRequestService";

@Component({
  selector: 'app-purchase-requests-edit',
  templateUrl: './purchase-requests-edit.component.html',
  styleUrls: ['./purchase-requests-edit.component.scss']
})
export class PurchaseRequestsEditComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router, private purchaseRequestService: PurchaseRequestService) { }

  private id: number;
  sub: any;
  purchaseRequest: any;



  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params=>{
      this.id =+params['id'];
    })
    this.getPurchaseRequest();

  }

  getPurchaseRequest(){
    this.purchaseRequest = this.purchaseRequestService.getById(this.id).subscribe(data=>{
      this.purchaseRequest = data;
    })
  }

  onChanged($event:any) {
    this.purchaseRequest.isCompleted = $event && $event.target && $event.target.checked;
  }

  editPurchaseRequest() {

    this.purchaseRequest.isCompleted? this.purchaseRequest.datePurchased=new Date(Date.now()):
      this.purchaseRequest.datePurchased=null;

    this.purchaseRequestService.update(this.purchaseRequest);
    this.router.navigateByUrl('purchase-requests');
  }

}
