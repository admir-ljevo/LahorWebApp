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
import { HomePageComponent } from './Components/home-page/home-page.component';
import {AutorizacijaLogin} from "./_guards/autorizacija-login";
import {AutorizacijaAdmin} from "./_guards/autorizacija-admin";
import {AutorizacijaKlijent} from "./_guards/autorizacija-klijent";
import {AutorizacijaUposlenik} from "./_guards/autorizacija-uposlenik";
import {AutorizacijaUpravnoOsoblje} from "./_guards/autorizacija-upravnoOsoblje";
import { ObavijestiComponent } from './Components/obavijesti/obavijesti.component';
import { NarudzbeComponent } from './Components/narudzbe/narudzbe.component';
import { PostavkeProfilaComponent } from './Components/postavke-profila/postavke-profila.component';

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
    UpravnoOsobljeComponent,
    HomePageComponent,
    ObavijestiComponent,
    NarudzbeComponent,
    PostavkeProfilaComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      {path: 'login', component: LoginComponent},
      {path: 'uposlenik', component: UposlenikComponent},
      {path: 'upravnoOsoblje', component: UpravnoOsobljeComponent},
      {path:'admin',component:AdminComponent},
      {path: 'klijent', component: KlijentComponent,canActivate:[AutorizacijaLogin]},
      {path: 'home', component: HomePageComponent,},
      {path: 'narudzbe', component: NarudzbeComponent,},
      {path: 'postavkeProfila', component: PostavkeProfilaComponent,},
      {path: 'obavijesti', component: ObavijestiComponent},
      {path: '**', component: HomePageComponent, canActivate: [AutorizacijaLogin]}
    ]),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    /*RouterModule.forRoot(appRoutes, {enableTracing:true}),*/
  ],
  providers: [
    AutorizacijaLogin,
    AutorizacijaAdmin,
    AutorizacijaKlijent,
    AutorizacijaUposlenik,
    AutorizacijaUpravnoOsoblje
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
