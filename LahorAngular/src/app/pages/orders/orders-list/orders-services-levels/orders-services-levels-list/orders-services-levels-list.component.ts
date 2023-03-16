import {Component, OnInit, TemplateRef} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {OrdersService} from "../../../../../services/OrdersService";
import {OrdersServicesLevelsService} from "../../../../../services/OrdersServicesLevelsService";
import {ActivatedRoute, Router} from "@angular/router";
import {filter, Observable} from "rxjs";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
@Component({
  selector: 'app-orders-services-levels-list',
  templateUrl: './orders-services-levels-list.component.html',
  styleUrls: ['./orders-services-levels-list.component.scss']
})
export class OrdersServicesLevelsListComponent implements OnInit {

  constructor(private httpClient: HttpClient,
              private ordersService: OrdersService,
              private ordersServicesLevelsService: OrdersServicesLevelsService,
              private route: ActivatedRoute,
              private  router: Router,
              private modalService: NgbModal) { }

  sub: any;
  selectedOrderServiceLevel: any;
  selectedOrder: any;
  ordersServicesLevels$!: Observable<any[]>;
  ordersServicesLevels: any = null;
  basicModalCloseResult: string = '';
  private id: number = 0;

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
    })
    this.getOrderById();
    this.getOrdersServicesLevels();

  }

  openBasicModal(content: TemplateRef<any>,x:any){
    this.selectedOrderServiceLevel = x;
    this.modalService.open(content, {}).result.then((result:any) => {
      this.basicModalCloseResult = "Modal closed" + result
    }).catch((res:any)=>console.log(res));
  }

  getOrderById() {
    this.selectedOrder = this.ordersService.getById(this.id).subscribe((data: any) => {
      this.selectedOrder = data;

    });
  }

  getOrdersServicesLevels() {
    this.ordersServicesLevels$ = this.ordersServicesLevelsService.getByOrderId(this.id);

  }


  addOrderServiceLevel(order: any){
    this.router.navigate(['orders/order-level-service-add', order.id])
  }

  setOrderPrice() {
    this.selectedOrder.price = 0;
    for (let i = 0; i < this.ordersServicesLevels.length; i++) {
      this.selectedOrder.price += this.ordersServicesLevels[i].totalPrice;
    }
    console.log(this.selectedOrder.price);
  }

  deleteOrderServiceLevel(modal: any){
    this.selectedOrder.price-=this.selectedOrderServiceLevel.totalPrice;
    this.ordersService.update(this.selectedOrder);
    this.ordersServicesLevelsService.delete(this.selectedOrderServiceLevel).subscribe(data=>{
      this.getOrdersServicesLevels()
    });
    modal.close('by: save button');
  }

  editOrderServiceLevel(orderServiceLevel: any){
    this.router.navigate(['orders/order-level-service-edit', orderServiceLevel.id]);
  }

  print() {
    window.print();
  }
}
