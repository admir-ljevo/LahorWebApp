import { RouterModule, Routes } from '@angular/router';
import { NewsListsComponent } from './news-lists.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsAddComponent } from '../news-add/news-add.component';
import { NewsEditComponent } from '../news-edit/news-edit.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import {
  NgbAlertModule,
  NgbModule,
  NgbPaginationModule,
  NgbTooltipModule,
} from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { TranslateModule } from '@ngx-translate/core';
import { FeahterIconModule } from 'src/app/core/feather-icon/feather-icon.module';
import { AuthEmployeeGuard } from 'src/app/core/guard/authEmployee.guard';
import { NewsPreviewComponent } from '../news-preview/news-preview.component';
import { AuthCompanyOwnerGuard } from 'src/app/core/guard/authCompanyOwner.guard';

const routes: Routes = [
  {
    canActivate: [AuthEmployeeGuard],
    path: '',
    component: NewsListsComponent,
  },
  {
    canActivate: [AuthEmployeeGuard],
    path: 'news-add',
    component: NewsAddComponent,
  },
  {
    canActivate: [AuthCompanyOwnerGuard],
    path: 'news-edit/:id',
    component: NewsEditComponent,
  },
  {
    path: 'news-preview/:id',
    component: NewsPreviewComponent,
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
    FormsModule,
    HttpClientModule,
    NgbModule,
  ],
})
export class NewsModule {}
