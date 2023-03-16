import {RouterModule, Routes} from "@angular/router";
import {OrdersListComponent} from "./orders-list/orders-list.component";
import {OrderAddComponent} from "./order-add/order-add.component";
import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";
import {SweetAlert2Module} from "@sweetalert2/ngx-sweetalert2";
import {NgbAlertModule, NgbPaginationModule, NgbTooltipModule} from "@ng-bootstrap/ng-bootstrap";
import {OrdersServicesLevelsAddComponent} from "./orders-list/orders-services-levels/orders-services-levels-add/orders-services-levels-add.component";
import {OrdersServicesLevelsListComponent} from "./orders-list/orders-services-levels/orders-services-levels-list/orders-services-levels-list.component";
import { OrdersServicesLevelsEditComponent } from './orders-list/orders-services-levels/orders-services-levels-edit/orders-services-levels-edit.component';

const routes: Routes = [
  {
    path: '',
    component: OrdersListComponent,
  },
  {
    path: 'add-order',
    component: OrderAddComponent,

  },
  {
    path: 'order-level-service-list/:id',
    component: OrdersServicesLevelsListComponent,
  },
  {
  path: 'order-level-service-add/:id',
  component: OrdersServicesLevelsAddComponent,
  },
  {
  path: 'order-level-service-edit/:id',
  component: OrdersServicesLevelsEditComponent,
  },

]
@NgModule({
  declarations: [OrdersListComponent ],
  imports: [CommonModule,
    RouterModule.forChild(routes),
    SweetAlert2Module.forRoot(),
    NgbPaginationModule,
    NgbAlertModule,
    NgbTooltipModule],
})
export class OrdersModule { }
