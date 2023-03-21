import { RouterModule, Routes } from '@angular/router';
import { ServicesListsComponent } from './services-list/services-lists.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ServicesAddComponent } from './services-add/services-add.component';
import { ServicesEditComponent } from './services-edit/services-edit.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import {
  NgbAlertModule,
  NgbPaginationModule,
  NgbTooltipModule,
} from '@ng-bootstrap/ng-bootstrap';
import { AuthEmployeeGuard } from 'src/app/core/guard/authEmployee.guard';
import { AuthCompanyOwnerGuard } from 'src/app/core/guard/authCompanyOwner.guard';

const routes: Routes = [
  {
    canActivate: [AuthEmployeeGuard],
    path: '',
    component: ServicesListsComponent,
  },
  {
    canActivate: [AuthCompanyOwnerGuard],
    path: 'services-add',
    component: ServicesAddComponent,
  },
  {
    canActivate: [AuthCompanyOwnerGuard],
    path: 'services-edit/:id',
    component: ServicesEditComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SweetAlert2Module.forRoot(),
    NgbPaginationModule,
    NgbAlertModule,
    NgbTooltipModule,

  ],
})
export class ServicesModule {}
