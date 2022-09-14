import {RouterModule, Routes} from "@angular/router";
import {NewsListsComponent} from "./news-lists.component";
import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";
import {NewsAddComponent} from "../news-add/news-add.component";
import {NewsEditComponent} from "../news-edit/news-edit.component";
import {SweetAlert2Module} from "@sweetalert2/ngx-sweetalert2";

const routes: Routes = [
  {
    path: '',
    component: NewsListsComponent,
  },
  {
    path: 'news-add',
    component: NewsAddComponent
  },
  {
    path: 'news-edit/:id',
    component: NewsEditComponent
  },
]

@NgModule({
  declarations: [NewsListsComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SweetAlert2Module.forRoot(),
  ]
})
export class NewsModule { }

