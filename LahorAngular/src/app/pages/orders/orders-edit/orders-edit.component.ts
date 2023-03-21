import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {OrdersService} from "../../../services/OrdersService";
import {ClientsService} from "../../../services/ClientsService";

@Component({
  selector: 'app-orders-edit',
  templateUrl: './orders-edit.component.html',
  styleUrls: ['./orders-edit.component.scss']
})
export class OrdersEditComponent implements OnInit {

  constructor(private router: Router,
              private route: ActivatedRoute,
              private ordersService: OrdersService,
              private  clientsService: ClientsService) { }

  private id: number;
  sub: any;
  order: any;
  clients: any;
  client: any;
  selectedClientId: number = 0;

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params=>{
      this.id =+params['id'];
    })
    this.getOrderById();
    this.getClients();
  }
  getOrderById(){
    this.order = this.ordersService.getById(this.id).subscribe(data=>{
      this.order = data;
      this.selectedClientId = this.order.clientId;

    })
  }
  getClients(){
    this.clientsService.getClients().subscribe((data) => {
      this.clients = data;
    });

  }

  changeClient(client: any) {
    this.selectedClientId = client.id;
    this.client = this.clientsService.getById(client.id).subscribe(data=>{
      this.client = data;
      this.order.clientName = client.person.firstName + " " + client.person.lastName;
    })
  }

  editOrder() {


     this.order.clientId = this.selectedClientId;
     this.ordersService.update(this.order).subscribe(data=>{
       this.order = data;
       this.router.navigateByUrl('/orders');
     })
  }

  onChanged($event: any) {
    this.order.delivered =  $event && $event.target && $event.target.checked;
    this.order.delivered? this.order.deliveryDate=new Date(Date.now()):
      this.order.deliveryDate=null;
  }
}
