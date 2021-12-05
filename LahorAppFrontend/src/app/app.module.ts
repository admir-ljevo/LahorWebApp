import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from "@angular/common/http";
import {RouterModule, Routes} from "@angular/router";

import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';

const appRoutes: Routes=[
  {path: '', component: AppComponent},
  {path: 'login', component: LoginComponent}

  ]

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes, {enableTracing:true}),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
