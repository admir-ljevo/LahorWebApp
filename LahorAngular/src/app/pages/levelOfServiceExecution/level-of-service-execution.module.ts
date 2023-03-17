import {RouterModule, Routes} from "@angular/router";
import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";
import {SweetAlert2Module} from "@sweetalert2/ngx-sweetalert2";
import {NgbAlertModule, NgbPaginationModule, NgbTooltipModule} from "@ng-bootstrap/ng-bootstrap";
import {LevelOfServiceExecutionListComponent} from "./level-of-service-execution-list/level-of-service-execution-list.component";
import { LevelOfServiceExecutionAddComponent } from './level-of-service-execution-add/level-of-service-execution-add.component';
import {FormsModule} from "@angular/forms";

const routes: Routes = [
  {
    path: '',
    component: LevelOfServiceExecutionListComponent,
  },
  {
    path: 'add',
    component: LevelOfServiceExecutionAddComponent,
  }
]
@NgModule({
  declarations: [LevelOfServiceExecutionListComponent, LevelOfServiceExecutionAddComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SweetAlert2Module.forRoot(),
    NgbPaginationModule,
    NgbAlertModule,
    NgbTooltipModule,
    FormsModule,
  ]
})
export class LevelOfServiceExecutionModule{

}

