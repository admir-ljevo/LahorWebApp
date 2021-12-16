import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginComponent} from './Components/login/login.component'
import {RegistracijaPravnoLiceComponent} from "./Components/registracija-pravno-lice/registracija-pravno-lice.component";
import {RegistracijaFizickoLiceComponent} from "./Components/registracija-fizicko-lice/registracija-fizicko-lice.component";
import {UspjesnaRegistracijaComponent} from "./Components/uspjesna-registracija/uspjesna-registracija.component";

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'registracija-fizicko-lice', component: RegistracijaFizickoLiceComponent },
  { path: 'registracija-pravno-lice', component: RegistracijaPravnoLiceComponent },
  { path: 'uspjesna-registracija', component: UspjesnaRegistracijaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const RoutingComponents=[LoginComponent,RegistracijaFizickoLiceComponent,RegistracijaPravnoLiceComponent,UspjesnaRegistracijaComponent]
