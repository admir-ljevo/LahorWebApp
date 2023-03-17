import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {MaterialsService} from "../../../services/MaterialsService";
import {PurchaseRequestService} from "../../../services/PurchaseRequestService";
import {MaterialRequestsService} from "../../../services/MaterialRequestsService";
import {Observable} from "rxjs";

@Component({
  selector: 'app-material-requests-edit',
  templateUrl: './material-requests-edit.component.html',
  styleUrls: ['./material-requests-edit.component.scss']
})
export class MaterialRequestsEditComponent implements OnInit {

  constructor(private router: Router,
              private route: ActivatedRoute,
              private materialRequestsService: MaterialRequestsService,
              private purchaseRequestsService: PurchaseRequestService,
              private materialsService: MaterialsService) { }

  private materialId: number

  private id: number;
  sub: any;

  materials: any[];
  materials$: Observable<any[]>;
  material$: Observable<any>;
  material: any;
  materialRequest: any;
  purchaseRequest: any;
  selectedMaterialId: number;
  oldPrice: number;
  amount: number;
  initialMaterialId: number;
  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params=>{
      this.materialId =+params['materialId'];
      this.id =+params['id'];
    })
    this.getMaterialRequestById();
    this.getMaterials();
    this.getPurchaseRequestByid();
  }

  getMaterialRequestById(): void{
    this.materialRequest = this.materialRequestsService.getById(this.materialId).subscribe(data=>{
      this.materialRequest = data;
      this.selectedMaterialId = this.materialRequest.materialId;
      this.oldPrice = this.materialRequest.totalPrice;
      console.log(this.selectedMaterialId);
    });
  }

  getMaterialById(){
   this.material$ = this.materialsService.getById(this.materialId);
   this.material$.subscribe(data=>{
     this.material = data;

   })
  }
  getMaterials(): void {
    this.materials$ = this.materialsService.getAll();
    this.materials$.subscribe(data=>{
      this.materials = data;
    });
  }

  getPurchaseRequestByid(): void{
    this.purchaseRequest = this.purchaseRequestsService.getById(this.id).subscribe(data=>{
      this.purchaseRequest = data;
    });
  }

  setPrice(){
    if(this.selectedMaterialId!=0){
      console.log('Selected Material: ', this.material);
      console.log('Amount: ', this.materialRequest.amount);
      console.log('Price: ', this.materialRequest.material.price);

      this.materialRequest.unitPrice=this.materialRequest.material.price;
      this.materialRequest.totalPrice=this.materialRequest.amount*this.materialRequest.unitPrice;

      console.log('Unit Price: ', this.materialRequest.unitPrice);
      console.log('Total Price: ', this.materialRequest.totalPrice);
    }
  }

  changeMaterial(material: any) {
    this.selectedMaterialId = material.id;
    this.materialRequest.material = this.materialsService.getById(material.id).subscribe(data=>{
      this.materialRequest.material=data;
      this.setPrice();
    });


  }

  editRequestItem() {
     this.materialRequest.materialId = this.selectedMaterialId;
     this.purchaseRequest.price-=this.oldPrice;
     this.purchaseRequest.price+=this.materialRequest.amount * this.materialRequest.unitPrice;
     this.purchaseRequestsService.update(this.purchaseRequest);
     this.materialRequestsService.update(this.materialRequest)
     this.router.navigate(['material-requests', this.id]);
  }
}
