import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {OrdersServicesLevelsService} from "../../../../../services/OrdersServicesLevelsService";
import {ActivatedRoute, Router} from "@angular/router";
import {OrderModel} from "../../../../../models/order-model";
import {OrdersService} from "../../../../../services/OrdersService";
import {Observable} from "rxjs";
import {MyConfig} from "../../../../../shared/MyConfig";
import {ServicesService} from "../../../../../services/ServicesService";
import {LevelOfServiceExecutionService} from "../../../../../services/LevelOfServiceExecutionService";
import {OrderServicesLevels} from "../../../../../models/order-services-levels";

@Component({
  selector: 'app-orders-services-levels-add',
  templateUrl: './orders-services-levels-add.component.html',
  styleUrls: ['./orders-services-levels-add.component.scss']
})
export class OrdersServicesLevelsAddComponent implements OnInit {

  constructor(private httpClient: HttpClient, private ordersService: OrdersService,private router: Router,private levelOfServiceExecutionService: LevelOfServiceExecutionService , private servicesService: ServicesService, private ordersServicesLevelsService: OrdersServicesLevelsService, private route: ActivatedRoute) { }

  sub: any;
  selectedOrder: any;
  private id: number = 0;
  services$!:Observable<any[]>;
  services: any;
  service: any;
  selectedSearchServiceId: number = 0;
  levelsOfServiceExecution$!: Observable<any[]>;
  levelsOfServiceExecution: any;
  selectedSearchLevelOfServiceExecutionId: number = 0;
  orderServiceLevel: OrderServicesLevels = new OrderServicesLevels();


  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
    })
    this.getOrderById();
    this.getServices();
    this.getLevelsOfServiceExecution();
  }

  getLevelsOfServiceExecution() {
    this.levelsOfServiceExecution$ = this.levelOfServiceExecutionService.getAll();
    this.levelsOfServiceExecution$.subscribe((data) => {
      this.levelsOfServiceExecution = data;
    })
  }

  getServices(){
    this.services$ = this.servicesService.getAll();
    this.services$.subscribe((data: any)=>{
      this.services = data
    });
  }

  getOrderById() {
    this.selectedOrder = this.ordersService.getById(this.id).subscribe((data: any) => {
      this.selectedOrder = data;
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  changeService(service: any){
    this.selectedSearchServiceId = service.id;
    this.service = this.servicesService.getById(service.id).subscribe((data: any) => {
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

  changeAmount(amount: number) {
    this.orderServiceLevel.amount = amount;
    this.setPrice();
  }

  addOrderServiceLevel(){
    this.orderServiceLevel.orderId = this.selectedOrder.id;
    this.orderServiceLevel.serviceId = this.selectedSearchServiceId;
    this.orderServiceLevel.levelOfServiceExecutionId = this.selectedSearchLevelOfServiceExecutionId;
    this.selectedOrder.price += this.orderServiceLevel.totalPrice;
    this.ordersService.update(this.selectedOrder);
    this.ordersServicesLevelsService.post(this.orderServiceLevel).subscribe(data=>{

      this.router.navigate(['orders/order-level-service-list', this.selectedOrder.id])
    })
  }

}
