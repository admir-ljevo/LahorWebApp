import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { PriceListPreviewComponent } from './price-list-preview/price-list-preview.component';

const routes: Routes = [
  {
    path: '',
    component: PriceListPreviewComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SweetAlert2Module.forRoot(),
  ],
})
export class PriceListModule {}
