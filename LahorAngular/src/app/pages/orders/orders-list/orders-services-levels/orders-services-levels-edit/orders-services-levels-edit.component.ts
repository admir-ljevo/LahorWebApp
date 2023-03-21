import { Component, OnInit } from '@angular/core';
import {OrdersServicesLevelsService} from "../../../../../services/OrdersServicesLevelsService";
import {ActivatedRoute, Route, Router} from "@angular/router";
import {OrdersService} from "../../../../../services/OrdersService";
import {ServicesService} from "../../../../../services/ServicesService";
import {LevelOfServiceExecutionService} from "../../../../../services/LevelOfServiceExecutionService";
import {Observable} from "rxjs";

@Component({
  selector: 'app-orders-services-levels-edit',
  templateUrl: './orders-services-levels-edit.component.html',
  styleUrls: ['./orders-services-levels-edit.component.scss']
})
export class OrdersServicesLevelsEditComponent implements OnInit {

  constructor(private orderServiceLevelService: OrdersServicesLevelsService,
              private route: ActivatedRoute,
              private ordersService: OrdersService,
              private serviceService: ServicesService,
              private levelOfServiceExecutionService: LevelOfServiceExecutionService,
              private router: Router) { }

  sub: any;
  private id: number;

  levelsOfServiceExecution$!: Observable<any[]>;
  levelsOfServiceExecutions: any;
  levelOfServiceExecution: any;
  selectedSearchLevelOfServiceExecutionId: number = 0;

  selectedSearchServiceId: number = 0;
  services$!: Observable<any[]>;
  service: any;
  services: any;

  orderServiceLevel$!: Observable<any>;
  orderServiceLevel: any;

  selectedOrder$!: Observable<any>;
  selectedOrder: any;

  oldPrice: number;

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.id=+params['id'];
    })
    this.getOrderServiceLevel();

  }

  getOrderServiceLevel(){
   this.orderServiceLevel = this.orderServiceLevelService.getById(this.id);
   this.orderServiceLevel.subscribe((data: any) => {
     this.orderServiceLevel = data;
     this.selectedSearchLevelOfServiceExecutionId = this.orderServiceLevel.levelOfServiceExecutionId;
     this.selectedSearchServiceId = this.orderServiceLevel.serviceId;
     this.oldPrice = this.orderServiceLevel.totalPrice;
     this.getServices();
     this.getLevelsOfServiceExecution();
     this.getOrder();

   });
  }

  getServices() {
    this.services$ = this.serviceService.getAll();
    this.services$.subscribe((data: any) => {
      this.services = data;
    })
  }

  getLevelsOfServiceExecution() {
    this.levelsOfServiceExecution$ = this.levelOfServiceExecutionService.getAll();
    this.levelsOfServiceExecution$.subscribe((data: any[]) => {
      this.levelsOfServiceExecutions = data;
    })
  }

  getOrder(){
    this.selectedOrder$ = this.ordersService.getById(this.orderServiceLevel.orderId);
    this.selectedOrder$.subscribe((data: any) => {
      this.selectedOrder = data;

    });
  }

  editOrderServiceLevel() {
    this.selectedOrder.price-=this.oldPrice;
    this.selectedOrder.price += this.orderServiceLevel.totalPrice;
    this.orderServiceLevel.levelOfServiceExecutionId = this.selectedSearchLevelOfServiceExecutionId;
    this.orderServiceLevel.serviceId = this.selectedSearchServiceId;
    this.ordersService.update(this.selectedOrder).subscribe(data=>{
      this.selectedOrder = data;
    });
    this.orderServiceLevelService.update(this.orderServiceLevel).subscribe(data=>{
      this.orderServiceLevel = data;
    });
    this.router.navigate(['orders/order-level-service-list', this.selectedOrder.id]);
  }

  changeAmount(amount: number) {
    this.orderServiceLevel.amount = amount;
    this.setPrice();
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  changeService(service: any){
    this.selectedSearchServiceId = service.id;
    this.service = this.serviceService.getById(service.id).subscribe((data: any) => {
      this.service = data;
      this.setPrice();

    });
  }
  changeLevelOfServiceExecution(levelOfServiceExecution: any){
    this.selectedSearchLevelOfServiceExecutionId = levelOfServiceExecution.id;
    this.setPrice();
  }


  setPrice() {
    if(this.selectedSearchLevelOfServiceExecutionId != 0 && this.selectedSearchServiceId != 0) {
      for (let i = 0; i < this.service.levelsPrices.length; i++) {
        if (this.service.levelsPrices[i].levelOfServiceExecutionId == this.selectedSearchLevelOfServiceExecutionId) {
          this.orderServiceLevel.unitPrice = this.service.levelsPrices[i].price;
          this.orderServiceLevel.totalPrice = this.orderServiceLevel.unitPrice * this.orderServiceLevel.amount;
          break;
        }
      }
    }
    return;
  }

}
