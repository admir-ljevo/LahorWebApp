import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { LayoutModule } from './views/layout/layout.module';
import { AuthGuard } from './core/guard/auth.guard';
import { AppComponent } from './app.component';
import { ErrorPageComponent } from './views/pages/error-page/error-page.component';
import { HIGHLIGHT_OPTIONS } from 'ngx-highlightjs';
import {HttpClientModule} from "@angular/common/http";
import {NewsAddComponent} from "./pages/news/news-add/news-add.component";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {NewsEditComponent} from "./pages/news/news-edit/news-edit.component";
import {NgbModule} from "@ng-bootstrap/ng-bootstrap";
import {AuthComponent} from "./views/pages/auth/auth.component";
import {CommonModule} from "@angular/common";
import {RouterModule} from "@angular/router";
import {ServicesAddComponent} from "./pages/services/services-add/services-add.component";
import {ServicesEditComponent} from "./pages/services/services-edit/services-edit.component";
import {NgSelectModule} from "@ng-select/ng-select";
import { OrderAddComponent } from './pages/orders/order-add/order-add.component';
import {OrdersServicesLevelsAddComponent} from "./pages/orders/orders-list/orders-services-levels/orders-services-levels-add/orders-services-levels-add.component";
import {OrdersServicesLevelsListComponent} from "./pages/orders/orders-list/orders-services-levels/orders-services-levels-list/orders-services-levels-list.component";
import {SweetAlert2Module} from "@sweetalert2/ngx-sweetalert2";
import {OrdersServicesLevelsEditComponent} from "./pages/orders/orders-list/orders-services-levels/orders-services-levels-edit/orders-services-levels-edit.component";
import {DeviceAddComponent} from "./pages/device/device-add/device-add.component";
import {DeviceEditComponent} from "./pages/device/device-edit/device-edit.component";
import { PurchaseRequestsListComponent } from './pages/purchaseRequests/purchase-requests-list/purchase-requests-list.component';
import { PurchaseRequestsAddComponent } from './pages/purchaseRequests/purchase-requests-add/purchase-requests-add.component';
import { PurchaseRequestsEditComponent } from './pages/purchaseRequests/purchase-requests-edit/purchase-requests-edit.component';
import { MaterialsListComponent } from './pages/materials/materials-list/materials-list.component';
import { MaterialsAddComponent } from './pages/materials/materials-add/materials-add.component';
import {MaterialsEditComponent} from "./pages/materials/materials-edit/materials-edit.component";
import { MaterialRequestsListComponent } from './pages/materialRequests/material-requests-list/material-requests-list.component';
import { MaterialRequestsAddComponent } from './pages/materialRequests/material-requests-add/material-requests-add.component';
import { MaterialRequestsEditComponent } from './pages/materialRequests/material-requests-edit/material-requests-edit.component';
import {LoginComponent} from "./views/pages/auth/login/login.component";
import {EmployeesAddComponent} from "./pages/employees/employees-add/employees-add.component";
import {CountriesListComponent} from "./pages/countries/countries-list/countries-list.component";
import {NgModule} from "@angular/core";
import {ReportingPreviewComponent} from "./pages/reporting/reporting-preview/reporting-preview.component";
import {
  EmployeesReportingComponent
} from "./pages/reporting/reporting-type/employees-reporting/employees-reporting.component";
import {AuthEmployeeGuard} from "./core/guard/authEmployee.guard";
import {EmployeesEditComponent} from "./pages/employees/employees-edit/employees-edit.component";
import {ArchwizardModule} from "angular-archwizard";
import {AuthAdminGuard} from "./core/guard/authAdmin.guard";
import {AuthCompanyOwnerGuard} from "./core/guard/authCompanyOwner.guard";
import {AuthClientGuard} from "./core/guard/authClient.guard";
import {RegisterComponent} from "./views/pages/auth/register/register.component";
import {CitiesListComponent} from "./pages/cities/cities-list/cities-list.component";
import {NgxMaskModule} from "ngx-mask";
import {TranslateModule} from "@ngx-translate/core";
import {ClientsListComponent} from "./pages/clients/client-list/client-list.component";
import {InputMaskComponent} from "./views/pages/advanced-form-elements/input-mask/input-mask.component";
import {
  ClientsReportingComponent
} from "./pages/reporting/reporting-type/clients-reporting/clients-reporting.component";
import {ToastrModule} from "ngx-toastr";
import {
  ServicesReportingComponent
} from "./pages/reporting/reporting-type/services-reporting/services-reporting.component";
import {EmployeesListComponent} from "./pages/employees/employees-list/employees-list.component";
import {NewsPreviewComponent} from "./pages/news/news-preview/news-preview.component";
import {QuillModule} from "ngx-quill";
import {ProfileComponent} from "./pages/profile/profile.component";
// @ts-ignore
import {PriceListPreviewComponent} from "./pages/PriceList/price-list-preview/price-list-preview.component";
import {ServicesListsComponent} from "./pages/services/services-list/services-lists.component";
import {NewsListsComponent} from "./pages/news/news-list/news-lists.component";
import {OrdersEditComponent} from "./pages/orders/orders-edit/orders-edit.component";


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ErrorPageComponent,
    NewsListsComponent,
    NewsAddComponent,
    NewsEditComponent,
    AuthComponent,
    ServicesEditComponent,
    ServicesAddComponent,
    ServicesListsComponent,
    OrderAddComponent,
    OrdersEditComponent,
    OrdersServicesLevelsAddComponent,
    OrdersServicesLevelsListComponent,
    OrdersServicesLevelsEditComponent,
    DeviceAddComponent,
    DeviceEditComponent,
    PurchaseRequestsAddComponent,
    PurchaseRequestsEditComponent,
    MaterialsAddComponent,
    MaterialsEditComponent,
    MaterialRequestsAddComponent,
    MaterialRequestsEditComponent,
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
    NewsPreviewComponent,
    ProfileComponent,
    InputMaskComponent,
    PriceListPreviewComponent,

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
    NgxMaskModule.forRoot({validation: true}),
    ToastrModule.forRoot(),
    QuillModule.forRoot(), // ngx-quill
    ArchwizardModule,
    SweetAlert2Module,
    // angular-archwizard
  ],
  exports:[FormsModule,
  ],

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
        }
      }
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
