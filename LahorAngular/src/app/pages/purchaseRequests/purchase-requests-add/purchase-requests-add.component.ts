import { Component, OnInit } from '@angular/core';
import {PurchaseRequestService} from "../../../services/PurchaseRequestService";
import {Router} from "@angular/router";
import {PurchaseRequestModel} from "../../../models/purchase-request-model";

@Component({
  selector: 'app-purchase-requests-add',
  templateUrl: './purchase-requests-add.component.html',
  styleUrls: ['./purchase-requests-add.component.scss']
})
export class PurchaseRequestsAddComponent implements OnInit {

  purchaseRequest: PurchaseRequestModel = new PurchaseRequestModel();
  constructor(private purchaseRequestService: PurchaseRequestService, private router: Router) { }

  ngOnInit(): void {
  }

  addPurchaseRequest() {
    this.purchaseRequestService.post(this.purchaseRequest).subscribe(data=>{
      this.router.navigateByUrl('purchase-requests')
    })
  }

}
