import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { LayoutModule } from './views/layout/layout.module';
import { AuthGuard } from './core/guard/auth.guard';
import { AppComponent } from './app.component';
import { ErrorPageComponent } from './views/pages/error-page/error-page.component';
import { HIGHLIGHT_OPTIONS } from 'ngx-highlightjs';
import { HttpClientModule } from '@angular/common/http';
import { NewsAddComponent } from './pages/news/news-add/news-add.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NewsEditComponent } from './pages/news/news-edit/news-edit.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AuthComponent } from './views/pages/auth/auth.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ServicesAddComponent } from './pages/services/services-add/services-add.component';
import { ServicesEditComponent } from './pages/services/services-edit/services-edit.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { TranslateModule } from '@ngx-translate/core';
import { ToastrModule } from 'ngx-toastr';
import { NewsListsComponent } from './pages/news/news-list/news-lists.component';
import { ServicesListsComponent } from './pages/services/services-list/services-lists.component';
import { CitiesListComponent } from './pages/cities/cities-list/cities-list.component';
import { CountriesListComponent } from './pages/countries/countries-list/countries-list.component';
import { PaginationService } from './shared/services/PaginationService';
import { ReportingPreviewComponent } from './pages/reporting/reporting-preview/reporting-preview.component';
import { ServicesReportingComponent } from './pages/reporting/reporting-type/services-reporting/services-reporting.component';
import { EmployeesListComponent } from './pages/employees/employees-list/employees-list.component';
import { EmployeesAddComponent } from './pages/employees/employees-add/employees-add.component';
import { QuillModule } from 'ngx-quill';
import { ArchwizardModule } from 'angular-archwizard';
import { LoginComponent } from './views/pages/auth/login/login.component';
import { RegisterComponent } from './views/pages/auth/register/register.component';
import { EmployeesEditComponent } from './pages/employees/employees-edit/employees-edit.component';
import { EmployeesReportingComponent } from './pages/reporting/reporting-type/employees-reporting/employees-reporting.component';
import { ClientsReportingComponent } from './pages/reporting/reporting-type/clients-reporting/clients-reporting.component';
import { ClientsListComponent } from './pages/clients/client-list/client-list.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { AuthAdminGuard } from './core/guard/authAdmin.guard';
import { AuthEmployeeGuard } from './core/guard/authEmployee.guard';
import { AuthCompanyOwnerGuard } from './core/guard/authCompanyOwner.guard';
import { AuthClientGuard } from './core/guard/authClient.guard';
import { PriceListPreviewComponent } from './pages/priceList/price-list-preview/price-list-preview.component';
import { NewsPreviewComponent } from './pages/news/news-preview/news-preview.component';
import { InputMaskComponent } from './views/pages/advanced-form-elements/input-mask/input-mask.component';
import { AdvancedFormElementsComponent } from './views/pages/advanced-form-elements/advanced-form-elements.component';
import { NgxMaskModule } from 'ngx-mask';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ErrorPageComponent,
    NewsListsComponent,
    NewsAddComponent,
    NewsEditComponent,
    PriceListPreviewComponent,
    AuthComponent,
    ServicesListsComponent,
    ServicesEditComponent,
    ServicesAddComponent,
    CountriesListComponent,
    CitiesListComponent,
    ReportingPreviewComponent,
    ServicesReportingComponent,
    EmployeesReportingComponent,
    ClientsReportingComponent,
    EmployeesListComponent,
    EmployeesAddComponent,
    EmployeesEditComponent,
    ClientsListComponent,
    ProfileComponent,
    NewsPreviewComponent,
    InputMaskComponent,
  ],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    RouterModule,
    AppRoutingModule,
    NgSelectModule,
    TranslateModule.forRoot(),
    NgxMaskModule.forRoot({ validation: true }),
    ToastrModule.forRoot(),
    QuillModule.forRoot(), // ngx-quill
    ArchwizardModule, // angular-archwizard
  ],
  exports: [FormsModule],
  providers: [
    AuthGuard,
    AuthAdminGuard,
    AuthCompanyOwnerGuard,
    AuthEmployeeGuard,
    AuthClientGuard,
    {
      provide: HIGHLIGHT_OPTIONS, // https://www.npmjs.com/package/ngx-highlightjs
      useValue: {
        coreLibraryLoader: () => import('highlight.js/lib/core'),
        languages: {
          xml: () => import('highlight.js/lib/languages/xml'),
          typescript: () => import('highlight.js/lib/languages/typescript'),
          scss: () => import('highlight.js/lib/languages/scss'),
        },
      },
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
