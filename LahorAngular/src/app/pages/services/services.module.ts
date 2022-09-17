import {RouterModule, Routes} from "@angular/router";
import {ServicesListsComponent} from "./services-list/services-lists.component";
import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";
import {ServicesAddComponent} from "./services-add/services-add.component";
import {ServicesEditComponent} from "./services-edit/services-edit.component";
import {SweetAlert2Module} from "@sweetalert2/ngx-sweetalert2";

const routes: Routes = [
  {
    path: '',
    component: ServicesListsComponent,
  },
  {
    path: 'services-add',
    component: ServicesAddComponent
  },
  {
    path: 'services-edit/:id',
    component: ServicesEditComponent
  },
]

@NgModule({
  declarations: [ServicesListsComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SweetAlert2Module.forRoot(),
  ]
})
export class ServicesModule { }

