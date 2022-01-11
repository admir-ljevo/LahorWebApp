import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from "@angular/common/http";
import {RouterModule, Routes} from "@angular/router";
import { AppRoutingModule } from './app-routing.module';
import { RegistracijaFizickoLiceComponent } from './Components/registracija-fizicko-lice/registracija-fizicko-lice.component';
import {UspjesnaRegistracijaComponent} from "./Components/uspjesna-registracija/uspjesna-registracija.component";
import {RegistracijaPravnoLiceComponent} from "./Components/registracija-pravno-lice/registracija-pravno-lice.component";
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
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
import {DodajObavijestComponent} from "./Components/dodaj-obavijest/dodaj-obavijest.component";
import { PregledEditObavijestiComponent } from './Components/obavijesti/pregled-edit-obavijesti/pregled-edit-obavijesti.component';
import {Ng2SearchPipeModule} from 'ng2-search-filter';
import {Ng2OrderModule} from "ng2-order-pipe";
import {NgxPaginationModule} from "ngx-pagination";
import { OnlineNarudzbeComponent } from './Components/online-narudzbe/online-narudzbe.component';
import { CjenovnikComponent } from './Components/cjenovnik/cjenovnik.component';
import { OnlineNarudzbeKlijentComponent } from './Components/online-narudzbe-klijent/online-narudzbe-klijent.component';
import { DodavanjeOnlineNarudzbeComponent } from './Components/dodavanje-online-narudzbe/dodavanje-online-narudzbe.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './Components/nav/nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { IzvjestajiComponent } from './Components/izvjestaji/izvjestaji.component';
import { DodajIzvjestajComponent } from './Components/dodaj-izvjestaj/dodaj-izvjestaj.component';

@NgModule({

  declarations: [
    AppComponent,
    LoginComponent,
    RegistracijaFizickoLiceComponent,
    RegistracijaPravnoLiceComponent,
    UspjesnaRegistracijaComponent,
    UposlenikComponent,
    AdminComponent,
    KlijentComponent,
    UpravnoOsobljeComponent,
    HomePageComponent,
    ObavijestiComponent,
    NarudzbeComponent,
    PostavkeProfilaComponent,
    DodajObavijestComponent,
    PregledEditObavijestiComponent,
    OnlineNarudzbeComponent,
    CjenovnikComponent,
    OnlineNarudzbeKlijentComponent,
    DodavanjeOnlineNarudzbeComponent,
    NavComponent,
    IzvjestajiComponent,
    DodajIzvjestajComponent
  ],
  imports: [
    BrowserModule,
    Ng2SearchPipeModule,
    Ng2OrderModule,
    NgxPaginationModule,
    RouterModule.forRoot([
      {path: 'login', component: LoginComponent},
      { path: 'registracija-fizicko-lice', component: RegistracijaFizickoLiceComponent },
      { path: 'registracija-pravno-lice', component: RegistracijaPravnoLiceComponent },
      { path: 'uspjesna-registracija', component: UspjesnaRegistracijaComponent },
      {path: 'uposlenik', component: UposlenikComponent},
      {path: 'upravnoOsoblje', component: UpravnoOsobljeComponent},
      {path:'admin',component:AdminComponent},
      {path: 'klijent', component: KlijentComponent,canActivate:[AutorizacijaLogin]},
      {path: 'home', component: HomePageComponent,},
      {path: 'narudzbe', component: NarudzbeComponent,},
      {path: 'postavkeProfila', component: PostavkeProfilaComponent,},
      {path: 'obavijesti', component: ObavijestiComponent},
      {path: 'dodajObavijest', component: DodajObavijestComponent},
      {path: 'onlineNarudzbe', component: OnlineNarudzbeComponent},
      {path: 'cjenovnik', component: CjenovnikComponent},
      {path: 'onlineNarudzbeKlijent', component: OnlineNarudzbeKlijentComponent},
      {path: 'dodavanjeOnlineNarudzbe', component: DodavanjeOnlineNarudzbeComponent},
      {path: 'izvjestaji', component: IzvjestajiComponent},
      {path: 'dodajIzvjestaj', component: DodajIzvjestajComponent},
      {path: 'nav', component: NavComponent},
      {path: '**', component: HomePageComponent, canActivate: [AutorizacijaLogin]}
    ]),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
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
