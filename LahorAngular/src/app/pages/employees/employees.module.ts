import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import {
  NgbAlertModule,
  NgbPaginationModule,
  NgbTooltipModule,
} from '@ng-bootstrap/ng-bootstrap';
import { EmployeesListComponent } from './employees-list/employees-list.component';
import { EmployeesAddComponent } from './employees-add/employees-add.component';
import { EmployeesEditComponent } from './employees-edit/employees-edit.component';

const routes: Routes = [
  {
    path: '',
    component: EmployeesListComponent,
  },
  {
    path: 'add',
    component: EmployeesAddComponent,
  },
  {
    path: 'edit/:id',
    component: EmployeesEditComponent,
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
export class EmployeesModule {}
