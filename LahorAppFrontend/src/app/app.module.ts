import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from "@angular/common/http";
import {RouterModule, Routes} from "@angular/router";
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {IMPLICIT_REFERENCE} from "@angular/compiler/src/render3/view/util";
import { UposlenikComponent } from './Components/uposlenik/uposlenik.component';
import { AdminComponent } from './Components/admin/admin.component';
import { KlijentComponent } from './Components/klijent/klijent.component';
import { UpravnoOsobljeComponent } from './Components/upravno-osoblje/upravno-osoblje.component';

/*const appRoutes: Routes=[
  {path: '', component: AppComponent},
  {path: 'login', component: LoginComponent}

  ]*/

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UposlenikComponent,
    AdminComponent,
    KlijentComponent,
    UpravnoOsobljeComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      {path: 'login', component: LoginComponent},
      {path: 'uposlenik', component: UposlenikComponent},
      {path: 'admin', component: AdminComponent},
      {path: 'upravnoOsoblje', component: UpravnoOsobljeComponent},
      {path: 'klijent', component: KlijentComponent}
    ]),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    /*RouterModule.forRoot(appRoutes, {enableTracing:true}),*/
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
