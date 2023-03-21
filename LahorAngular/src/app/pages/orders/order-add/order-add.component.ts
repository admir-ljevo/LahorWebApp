import { Component, OnInit } from '@angular/core';
import {OrdersService} from "../../../services/OrdersService";
import {Router} from "@angular/router";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {OrderModel} from "../../../models/order-model";
import {ClientsService} from "../../../services/ClientsService";

@Component({
  selector: 'app-order-add',
  templateUrl: './order-add.component.html',
  styleUrls: ['./order-add.component.scss']
})
export class OrderAddComponent implements OnInit {
  order:OrderModel = new OrderModel();
  constructor(private ordersService: OrdersService,
              private router: Router,
              private modalService: NgbModal,
              private clientsService: ClientsService ) { }

  clients: any;
  client: any;
  selectedClientId: number;

  ngOnInit(): void {
    this.getClients();
  }

  addOrder(){
    this.order.clientId = this.selectedClientId;
    this.ordersService.post(this.order).subscribe(data=>{this.router.navigateByUrl("/orders")});
  }

  getClients(){
    this.clientsService.getClients().subscribe((data) => {
      this.clients = data;
      console.log(this.clients.length);
    });
  }

  changeClient(client: any) {
    this.selectedClientId = client.id;
    this.client = this.clientsService.getById(client.id).subscribe(data=>{
      this.client = data;
      this.order.clientName = client.person.firstName + " " + client.person.lastName;
    })
  }
}
