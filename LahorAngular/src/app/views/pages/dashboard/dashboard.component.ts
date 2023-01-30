import { animate, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthAdminGuard } from 'src/app/core/guard/authAdmin.guard';
import { AuthCompanyOwnerGuard } from 'src/app/core/guard/authCompanyOwner.guard';
import { AuthEmployeeGuard } from 'src/app/core/guard/authEmployee.guard';
import { DashboardService } from 'src/app/services/DashboardService';
import { NewsService } from 'src/app/services/NewsService';
import { MyConfig } from 'src/app/shared/MyConfig';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  preserveWhitespaces: true,
  animations: [
    trigger('fade', [
      transition('void => *', [
        style({ opacity: 0 }),
        animate('300ms', style({ opacity: 1 })),
      ]),
      transition('* => void', [
        style({ opacity: 1 }),
        animate('300ms', style({ opacity: 0 })),
      ]),
    ]),
  ],
})
export class DashboardComponent implements OnInit {
  /**
   * Apex chart
   */
  public employeesChartOptions: any = {};
  public clientsChartOptions: any = {};
  public servicesChartOptions: any = {};

  // colors and font variables for apex chart
  obj = {
    primary: '#6571ff',
    secondary: '#7987a1',
    success: '#05a34a',
    info: '#66d1d1',
    warning: '#fbbc06',
    danger: '#ff3366',
    light: '#e9ecef',
    dark: '#060c17',
    muted: '#7987a1',
    gridBorder: 'rgba(77, 138, 240, .15)',
    bodyColor: '#000',
    cardBg: '#fff',
    fontFamily: "'Roboto', Helvetica, sans-serif",
  };

  news: any;
  lastFiveNews: any;
  dashboardData: any;
  public current = 0;

  constructor(
    private newsService: NewsService,
    private router: Router,
    private dashboardService: DashboardService
  ) {}

  ngOnInit(): void {
    this.dashboardService.getStatistics().subscribe((data: any) => {
      this.dashboardData = data;
      this.employeesChartOptions = getEmployeesChartOptions(
        this.obj,
        this.dashboardData?.employeesDashboardData?.employeesCountByMonth
      );
      this.clientsChartOptions = getClientsChartOptions(
        this.obj,
        this.dashboardData?.clientsDashboardData?.clientsCountByMonth
      );
      this.servicesChartOptions = getServicesChartOptions(
        this.obj,
        this.dashboardData?.servicesDashboardData?.servicesCountByMonth
      );
    });
    this.newsService.getLastFiveNews(true).subscribe((data: any) => {
      this.news = data;
      setInterval(() => {
        this.current = ++this.current % this.news.length;
      }, 5000);
    });
    this.newsService.getLastFiveNews(false).subscribe((data: any) => {
      this.lastFiveNews = data;
    });
  }

  get isAdmin() {
    return AuthAdminGuard.isActive();
  }

  get isCompanyOwner() {
    return AuthCompanyOwnerGuard.isActive();
  }

  get isEmployee() {
    return AuthEmployeeGuard.isActive();
  }

  detailNew(id: any) {
    this.router.navigate(['/news/news-preview', id]);
  }

  public createImageUrl = (imgSrc: string) => {
    return MyConfig.address_server_base + imgSrc;
  };
}

function getEmployeesChartOptions(obj: any, employeeCount: any) {
  return {
    series: [
      {
        name: '',
        data: employeeCount,
      },
    ],
    chart: {
      type: 'bar',
      height: 60,
      sparkline: {
        enabled: !0,
      },
    },
    colors: [obj.primary],
    xaxis: {
      type: 'datetime',
      categories: [
        'Jan 01 2022',
        'Feb 01 2022',
        'Mar 01 2022',
        'Apr 01 2022',
        'May 01 2022',
        'Jun 01 2022',
        'Jul 01 2022',
        'Aug 01 2022',
        'Sep 01 2022',
        'Oct 01 2022',
        'Nov 01 2022',
        'Dec 01 2022',
      ],
    },
    stroke: {
      width: 2,
      curve: 'smooth',
    },
    markers: {
      size: 0,
    },
  };
}

function getClientsChartOptions(obj: any, clientsCount: any) {
  return {
    series: [
      {
        name: '',
        data: clientsCount,
      },
    ],
    chart: {
      type: 'bar',
      height: 60,
      sparkline: {
        enabled: !0,
      },
    },
    colors: [obj.primary],
    xaxis: {
      type: 'datetime',
      categories: [
        'Jan 01 2022',
        'Feb 01 2022',
        'Mar 01 2022',
        'Apr 01 2022',
        'May 01 2022',
        'Jun 01 2022',
        'Jul 01 2022',
        'Aug 01 2022',
        'Sep 01 2022',
        'Oct 01 2022',
        'Nov 01 2022',
        'Dec 01 2022',
      ],
    },
    stroke: {
      width: 2,
      curve: 'smooth',
    },
    markers: {
      size: 0,
    },
  };
}

function getServicesChartOptions(obj: any, servicesCount: any) {
  return {
    series: [
      {
        name: '',
        data: servicesCount,
      },
    ],
    chart: {
      type: 'line',
      height: 60,
      sparkline: {
        enabled: !0,
      },
    },
    colors: [obj.primary],
    xaxis: {
      type: 'datetime',
      categories: [
        'Jan 01 2022',
        'Feb 01 2022',
        'Mar 01 2022',
        'Apr 01 2022',
        'May 01 2022',
        'Jun 01 2022',
        'Jul 01 2022',
        'Aug 01 2022',
        'Sep 01 2022',
        'Oct 01 2022',
        'Nov 01 2022',
        'Dec 01 2022',
      ],
    },
    stroke: {
      width: 2,
      curve: 'smooth',
    },
    markers: {
      size: 0,
    },
  };
}
