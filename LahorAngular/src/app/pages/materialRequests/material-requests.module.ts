import {RouterModule, Routes} from "@angular/router";
import {MaterialRequestsListComponent} from "./material-requests-list/material-requests-list.component";
import {MaterialRequestsAddComponent} from "./material-requests-add/material-requests-add.component";
import {MaterialRequestsEditComponent} from "./material-requests-edit/material-requests-edit.component";
import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";
import {SweetAlert2Module} from "@sweetalert2/ngx-sweetalert2";
import {NgbAlertModule, NgbPaginationModule, NgbTooltipModule} from "@ng-bootstrap/ng-bootstrap";
import {FormsModule} from "@angular/forms";

const routes: Routes = [
  {
    path: ':id',
    component: MaterialRequestsListComponent
  },
  {
    path: ':id/material-requests/add',
    component: MaterialRequestsAddComponent
  },
  {
    path: ':id/material-requests/edit/:materialId',
    component: MaterialRequestsEditComponent
  }
];

@NgModule({
  declarations: [MaterialRequestsListComponent],
  imports: [CommonModule,
    RouterModule.forChild(routes),
    SweetAlert2Module.forRoot(),
    NgbPaginationModule,
    NgbAlertModule,
    NgbTooltipModule, FormsModule],
})
export class MaterialRequestsModule {}
