import { Component, OnInit, TemplateRef } from '@angular/core';
import { TranslationService } from 'src/app/shared/i18n';
import { Router } from '@angular/router';
import { AuthAdminGuard } from 'src/app/core/guard/authAdmin.guard';
import { AuthCompanyOwnerGuard } from 'src/app/core/guard/authCompanyOwner.guard';
@Component({
  selector: 'app-news',
  templateUrl: './reporting-preview.component.html',
  styleUrls: ['./reporting-preview.component.scss'],
})
export class ReportingPreviewComponent implements OnInit {
  constructor(private t: TranslationService, private router: Router) {}

  ngOnInit() {}

  serviceReport() {
    this.router.navigateByUrl('reporting/services');
  }

  employeesReport() {
    this.router.navigateByUrl('reporting/employees');
  }

  clientsReport() {
    this.router.navigateByUrl('reporting/clients');
  }

  get isAdmin() {
    return AuthAdminGuard.isActive();
  }

  get isCompanyOwner() {
    return AuthCompanyOwnerGuard.isActive();
  }
}
