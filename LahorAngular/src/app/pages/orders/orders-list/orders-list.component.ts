import { Component, OnInit } from '@angular/core';
import {OrdersService} from "../../../services/OrdersService";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {Router} from "@angular/router";
import {Observable} from "rxjs";

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.scss']
})
export class OrdersListComponent implements OnInit {

  constructor(private ordersService: OrdersService, private router: Router, private modalService: NgbModal) { }
  orders$: Observable<any[]>;
  ngOnInit(): void {
    this.getAllOrders();
  }

  addNewOrder() {
    this.router.navigateByUrl('/orders/add-order')
  }

  getAllOrders() {
    this.orders$ = this.ordersService.getAll();
  }

  addOrderServiceLevel(order: any){
    this.router.navigate(['orders/order-level-service-list', order.id])
  }

}
