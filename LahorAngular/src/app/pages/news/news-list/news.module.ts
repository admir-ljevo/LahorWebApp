import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import {WidgetsModule} from "../../../_metronic/partials";
import {InlineSVGModule} from "ng-inline-svg";
import {NewsListsComponent} from "./news-lists.component";

@NgModule({
  declarations: [NewsListsComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        component: NewsListsComponent,
      },
    ]),
    WidgetsModule,
    InlineSVGModule,
  ],
})
export class NewsModule {}
