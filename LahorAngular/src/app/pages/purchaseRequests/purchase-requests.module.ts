import {PurchaseRequestsListComponent} from "./purchase-requests-list/purchase-requests-list.component";
import {RouterModule, Routes} from "@angular/router";
import {PurchaseRequestsAddComponent} from "./purchase-requests-add/purchase-requests-add.component";
import {PurchaseRequestsEditComponent} from "./purchase-requests-edit/purchase-requests-edit.component";
import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";
import {SweetAlert2Module} from "@sweetalert2/ngx-sweetalert2";
import {NgbAlertModule, NgbPaginationModule, NgbTooltipModule} from "@ng-bootstrap/ng-bootstrap";

const routes: Routes = [
  {
    path: '',
    component: PurchaseRequestsListComponent
  },
  {
    path: 'add-purchase-request',
    component: PurchaseRequestsAddComponent
  },
  {
    path: 'edit-purchase-request/:id',
    component: PurchaseRequestsEditComponent,
  }
]
@NgModule({
  declarations: [PurchaseRequestsListComponent ],
  imports: [CommonModule,
    RouterModule.forChild(routes),
    SweetAlert2Module.forRoot(),
    NgbPaginationModule,
    NgbAlertModule,
    NgbTooltipModule],
})

export class PurchaseRequestsModule { }
