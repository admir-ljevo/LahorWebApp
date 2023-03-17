import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BaseComponent } from './base/base.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FooterComponent } from './footer/footer.component';
import { ContentAnimateDirective } from '../../core/content-animate/content-animate.directive';
import {
  NgbDropdownModule,
  NgbCollapseModule,
} from '@ng-bootstrap/ng-bootstrap';
import { FeahterIconModule } from '../../core/feather-icon/feather-icon.module';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import { TranslateModule } from '@ngx-translate/core';
import { TranslationModule } from 'src/app/shared/i18n';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true,
};

@NgModule({
  declarations: [
    BaseComponent,
    NavbarComponent,
    SidebarComponent,
    FooterComponent,
    ContentAnimateDirective,
  ],
  imports: [
    CommonModule,
    TranslationModule,
    RouterModule,
    FormsModule,
    NgbDropdownModule,
    NgbCollapseModule,
    PerfectScrollbarModule,
    FeahterIconModule,
    TranslateModule.forRoot(),
  ],
  providers: [
    {
      provide: PERFECT_SCROLLBAR_CONFIG,
      useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG,
    },
  ],
})
export class LayoutModule {}
