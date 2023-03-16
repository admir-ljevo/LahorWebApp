import { Component, OnInit } from '@angular/core';
import {OrdersService} from "../../../services/OrdersService";
import {Router} from "@angular/router";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {OrderModel} from "../../../models/order-model";

@Component({
  selector: 'app-order-add',
  templateUrl: './order-add.component.html',
  styleUrls: ['./order-add.component.scss']
})
export class OrderAddComponent implements OnInit {
  order:OrderModel = new OrderModel();
  constructor(private ordersService: OrdersService, private router: Router, private modalService: NgbModal ) { }

  ngOnInit(): void {
  }

  addOrder(){
    this.ordersService.post(this.order).subscribe(data=>{this.router.navigateByUrl("/orders")});
  }

}
