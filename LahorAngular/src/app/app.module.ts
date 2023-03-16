import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
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


@NgModule({
  declarations: [
    AppComponent,
    ErrorPageComponent,
    NewsAddComponent,
    NewsEditComponent,
    AuthComponent,
    ServicesEditComponent,
    ServicesAddComponent,
    OrderAddComponent,
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
  ],
    imports: [
        BrowserAnimationsModule,
        CommonModule,
        ReactiveFormsModule,
        FormsModule,
        HttpClientModule,
        NgbModule,
        RouterModule,
        AppRoutingModule,
        FormsModule,
        NgSelectModule,
        SweetAlert2Module,
    ],
  exports:[FormsModule],
  providers: [
    AuthGuard,
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
