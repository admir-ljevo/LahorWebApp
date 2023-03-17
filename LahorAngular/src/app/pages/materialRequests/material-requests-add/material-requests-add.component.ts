import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {MaterialRequestsService} from "../../../services/MaterialRequestsService";
import {PurchaseRequestService} from "../../../services/PurchaseRequestService";
import {MaterialsService} from "../../../services/MaterialsService";
import {Observable} from "rxjs";
import {MaterialRequestModel} from "../../../models/material-request-model";

@Component({
  selector: 'app-material-requests-add',
  templateUrl: './material-requests-add.component.html',
  styleUrls: ['./material-requests-add.component.scss']
})
export class MaterialRequestsAddComponent implements OnInit {

  constructor(private router: Router, private route: ActivatedRoute,
              private materialRequestsService: MaterialRequestsService,
              private purchaseRequestService: PurchaseRequestService,
              private materialsService: MaterialsService) { }


  sub: any;
  private id: number;
  purchaseRequest: any;
  materials$: Observable<any[]>;
  materials: any[];
  material: any;
  selectedMaterialId: number;
  materialRequest: MaterialRequestModel = new MaterialRequestModel();

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params=>{
      this.id=+params['id'];
    })
    this.getPurchaseRequestById();
    this.getMaterials();
  }
  getPurchaseRequestById(){
    this.purchaseRequest = this.purchaseRequestService.getById(this.id).subscribe(data=>{
      this.purchaseRequest=data;
    });

  }
  getMaterials(){
    this.materials$ = this.materialsService.getAll();
    this.materials$.subscribe(data=>{
      this.materials = data;
    })
  }


  setPrice(){
    if(this.selectedMaterialId!=0){
      this.materialRequest.unitPrice=this.material.price;
      this.materialRequest.totalPrice=this.materialRequest.amount*this.materialRequest.unitPrice;
    }
  }

  changeMaterial(material: any) {
     this.selectedMaterialId = material.id;
     this.material = this.materialsService.getById(material.id).subscribe(data=>{
     this.material=data;
     this.setPrice();
     });

  }

  changeAmount(amount: number) {
  this.materialRequest.amount = amount;
  this.setPrice();
  }

  addRequestItem() {
   this.materialRequest.materialId=this.material.id;
   this.materialRequest.purchaseRequestId = this.purchaseRequest.id;
   this.purchaseRequest.price += this.materialRequest.totalPrice;
   this.purchaseRequestService.update(this.purchaseRequest);
   this.materialRequestsService.post(this.materialRequest).subscribe(data=>{
     this.router.navigate(['material-requests', this.id]);
   })
  }
}
