import {RouterModule, Routes} from "@angular/router";
import {DeviceListComponent} from "./device-list/device-list.component";
import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";
import {SweetAlert2Module} from "@sweetalert2/ngx-sweetalert2";
import {NgbAlertModule, NgbPaginationModule, NgbTooltipModule} from "@ng-bootstrap/ng-bootstrap";
import { DeviceAddComponent } from './device-add/device-add.component';
import { DeviceEditComponent } from './device-edit/device-edit.component';

const routes: Routes = [
  {
    path: '',
    component: DeviceListComponent,
  },
  {
    path: 'add-device',
    component: DeviceAddComponent ,
  },
  {
    path: 'edit-device/:id',
    component: DeviceEditComponent
  },
]
@NgModule({
  declarations: [DeviceListComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SweetAlert2Module.forRoot(),
    NgbPaginationModule,
    NgbAlertModule,
    NgbTooltipModule
  ],
})
export class DeviceModule { }
