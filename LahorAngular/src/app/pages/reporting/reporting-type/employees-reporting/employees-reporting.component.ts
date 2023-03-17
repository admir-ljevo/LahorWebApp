import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { TranslationService } from 'src/app/shared/i18n';
import { PaginationService } from 'src/app/shared/services/PaginationService';
import { ReportsService } from 'src/app/services/ReportsService';
import { ReportSearchObject } from 'src/app/searchObject/ReportSearchObject';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ReportType } from 'src/app/core/enumerations/reportType';
@Component({
  selector: 'app-news',
  templateUrl: './employees-reporting.component.html',
  styleUrls: ['./employees-reporting.component.scss'],
})
export class EmployeesReportingComponent implements OnInit {
  employees: any;
  currentPage: any = 1;
  oldCurrentPage: any = this.currentPage;
  pageSize: any = 2;
  collectionSize: any = 0;
  message: string;
  itemsPerPage: any;
  search = new ReportSearchObject();
  form = new FormGroup({
    dateFrom: new FormControl('', Validators.required),
    dateTo: new FormControl('', Validators.required),
  });

  constructor(
    private router: Router,
    private toastr: ToastrService,
    private t: TranslationService,
    private paginationService: PaginationService,
    private reportsService: ReportsService,
    private formatter: NgbDateParserFormatter
  ) {}

  ngOnInit() {
    this.itemsPerPage = this.paginationService.getItemsPerPage();
    this.pageSize = this.itemsPerPage[0];
  }

  createReport(data: any) {
    this.search.reportType = ReportType.Preview;
    this.generateReport(data);
  }

  printReport(data: any) {
    this.search.reportType = ReportType.PDF;
    this.generateReport(data);
  }

  downloadReport(data: any) {
    this.search.reportType = ReportType.PDF;
    this.generateReport(data);
    this.search.reportType = ReportType.Download;
  }

  generateReport(data: any) {
    this.search.dateFrom = this.formatter.format(data.dateFrom);
    this.search.dateTo = this.formatter.format(data.dateTo);
    this.reportsService
      .generateEmployeesReport(this.search)
      .subscribe((data: any) => {
        if (this.search.reportType == ReportType.Preview) {
          this.employees = data;
          if (this.employees.length > 0) {
            this.collectionSize = this.paginationService.getCollectionSize(
              this.pageSize,
              data[0].totalRecordsCount
            );
          }
        } else if (this.search.reportType == ReportType.PDF) {
          this.openPdf(data);
        } else if (this.search.reportType == ReportType.Download) {
          this.downloadPdf(data);
        }
      });
  }

  openPdf(data: any) {
    const blob = new Blob([data], { type: 'application/pdf' }); // you can change the type
    const url = window.URL.createObjectURL(blob);
    window.open(url);
  }

  downloadPdf(data: any) {
    var downloadURL = window.URL.createObjectURL(data);
    var link = document.createElement('a');
    link.href = downloadURL;
    link.download = 'Employees_Report.pdf';
    link.click();
  }

  get dateFrom() {
    return this.form.get('dateFrom');
  }

  get dateTo() {
    return this.form.get('dateTo');
  }
}
