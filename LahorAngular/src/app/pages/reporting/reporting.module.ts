import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { ReportingPreviewComponent } from './reporting-preview/reporting-preview.component';
import {
  NgbAlertModule,
  NgbPaginationModule,
  NgbTooltipModule,
} from '@ng-bootstrap/ng-bootstrap';
import { ServicesReportingComponent } from './reporting-type/services-reporting/services-reporting.component';
import { EmployeesReportingComponent } from './reporting-type/employees-reporting/employees-reporting.component';
import { ClientsReportingComponent } from './reporting-type/clients-reporting/clients-reporting.component';
import { AuthEmployeeGuard } from 'src/app/core/guard/authEmployee.guard';
import { AuthClientGuard } from 'src/app/core/guard/authClient.guard';

const routes: Routes = [
  {
    canActivate: [AuthEmployeeGuard],
    path: '',
    component: ReportingPreviewComponent,
  },
  {
    canActivate: [AuthEmployeeGuard],
    path: 'services',
    component: ServicesReportingComponent,
  },
  {
    canActivate: [AuthClientGuard],
    path: 'employees',
    component: EmployeesReportingComponent,
  },
  {
    canActivate: [AuthEmployeeGuard],
    path: 'clients',
    component: ClientsReportingComponent,
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
export class ReportingModule {}
