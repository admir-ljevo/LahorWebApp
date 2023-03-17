import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { CitiesListComponent } from './cities-list/cities-list.component';
import {
  NgbAlertModule,
  NgbPaginationModule,
  NgbTooltipModule,
} from '@ng-bootstrap/ng-bootstrap';

const routes: Routes = [
  {
    path: '',
    component: CitiesListComponent,
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
export class CitiesModule {}
