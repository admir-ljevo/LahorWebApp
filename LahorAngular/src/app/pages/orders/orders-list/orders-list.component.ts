import {Component, OnInit, TemplateRef} from '@angular/core';
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
  private basicModalCloseResult: string = '';

  constructor(private ordersService: OrdersService, private router: Router, private modalService: NgbModal) { }
  orders$: Observable<any[]>;
  selectedOrder: any;
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

  editOrder(id: number) {
    this.router.navigate(['orders/edit-order/',id]);
  }

  deleteOrder(modal: any) {
   this.ordersService.delete(this.selectedOrder).subscribe(data=>{
     this.getAllOrders();
   })
    modal.close('by: save button');

  }

  openBasicModal(content: TemplateRef<any>,x: any) {
    this.selectedOrder = x;
    this.modalService.open(content, {}).result.then((result:any) => {
      this.basicModalCloseResult = "Modal closed" + result
    }).catch((res:any)=>console.log(res));
   }
}
