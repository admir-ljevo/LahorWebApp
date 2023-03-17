import {Router, RouterModule, Routes} from "@angular/router";
import {MaterialsListComponent} from "./materials-list/materials-list.component";
import {MaterialsEditComponent} from "./materials-edit/materials-edit.component";
import {MaterialsAddComponent} from "./materials-add/materials-add.component";
import {NgModule} from "@angular/core";
import {
  PurchaseRequestsListComponent
} from "../purchaseRequests/purchase-requests-list/purchase-requests-list.component";
import {CommonModule} from "@angular/common";
import {SweetAlert2Module} from "@sweetalert2/ngx-sweetalert2";
import {NgbAlertModule, NgbPaginationModule, NgbTooltipModule} from "@ng-bootstrap/ng-bootstrap";
import {FormsModule} from "@angular/forms";

const routes: Routes = [
  {
    path:'',
    component: MaterialsListComponent
  },
  {
    path: 'materials-edit/:id',
    component: MaterialsEditComponent
  },
  {
    path: 'materials-add',
    component: MaterialsAddComponent
  }
]
@NgModule({
  declarations: [MaterialsListComponent],
    imports: [CommonModule,
        RouterModule.forChild(routes),
        SweetAlert2Module.forRoot(),
        NgbPaginationModule,
        NgbAlertModule,
        NgbTooltipModule, FormsModule],
})
export class MaterialsModule {}
