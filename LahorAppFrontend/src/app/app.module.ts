import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from "@angular/common/http";
import {RouterModule, Routes} from "@angular/router";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { RegistracijaFizickoLiceComponent } from './Components/registracija-fizicko-lice/registracija-fizicko-lice.component';
import {FormsModule} from "@angular/forms";
import {UspjesnaRegistracijaComponent} from "./Components/uspjesna-registracija/uspjesna-registracija.component";
import {RegistracijaPravnoLiceComponent} from "./Components/registracija-pravno-lice/registracija-pravno-lice.component";

const appRoutes: Routes=[
  {path: '', component: AppComponent},
  {path: 'login', component: LoginComponent}

  ]

@NgModule({
    declarations: [
        AppComponent,
        LoginComponent,
        RegistracijaFizickoLiceComponent,
        RegistracijaPravnoLiceComponent,
        UspjesnaRegistracijaComponent,
    ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes, {enableTracing:true}),
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
