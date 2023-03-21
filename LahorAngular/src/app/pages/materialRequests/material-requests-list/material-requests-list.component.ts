import {Component, OnInit, TemplateRef} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {MaterialRequestsService} from "../../../services/MaterialRequestsService";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {PurchaseRequestService} from "../../../services/PurchaseRequestService";
import {date} from "ngx-custom-validators/src/app/date/validator";
import {Observable} from "rxjs";

@Component({
  selector: 'app-material-requests-list',
  templateUrl: './material-requests-list.component.html',
  styleUrls: ['./material-requests-list.component.scss']
})
export class MaterialRequestsListComponent implements OnInit {

  constructor(private router: Router,
              private route: ActivatedRoute,
              private modalService: NgbModal,

              private purchaseRequestService: PurchaseRequestService,
              private materialRequestsService: MaterialRequestsService) { }

  private id: number;
  sub: any;
  materials$: any;
  materials: any[];

  selectedMaterialRequest: any;
  purchaseRequest: any;
  basicModalCloseResult: string = '';

  printRequest: boolean;
  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params=>{
      this.id =+params['id'];
    })
    this.getMaterialsByRequestId();
    this.getPurchaseRequestById();
  }

  getMaterialsByRequestId(){
    this.materials$ = this.materialRequestsService.getByRequestId(this.id).subscribe(data=>{
      this.materials = data;
    });
  }

  getPurchaseRequestById(){
    this.purchaseRequest = this.purchaseRequestService.getById(this.id).subscribe(data=>{
      this.purchaseRequest = data;
    });
  }

  addPurchaseRequestItem(){
    this.router.navigateByUrl(`material-requests/${this.id}/material-requests/add`)
  }

  openBasicModal(content: TemplateRef<any>,x:any){
    this.selectedMaterialRequest = x;
    this.modalService.open(content, {}).result.then((result:any) => {
      this.basicModalCloseResult = "Modal closed" + result
    }).catch((res:any)=>console.log(res));
  }

  deleteRequestItem(modal: any){
    this.purchaseRequest.price-=this.selectedMaterialRequest.totalPrice;
    this.purchaseRequestService.update(this.purchaseRequest).subscribe(data=>{
      this.purchaseRequest = data;
    });
    this.materialRequestsService.delete(this.selectedMaterialRequest).subscribe(data=>{
      this.getMaterialsByRequestId();
    })
    modal.close('by: save button');
  }

  editRequestItem(material: any){
    this.router.navigateByUrl(`material-requests/${this.id}/material-requests/edit/${material.id}`)
  }

  print(){
    window.print();
  }

}
