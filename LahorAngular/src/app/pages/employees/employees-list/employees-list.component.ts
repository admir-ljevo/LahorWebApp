import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeesService } from 'src/app/services/EmployeesService';
import { MyConfig } from 'src/app/shared/MyConfig';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.scss'],
})
export class EmployeesListComponent implements OnInit {
  employees: any;
  baseUrl = MyConfig.address_server_base;
  imgSrc: any = '../../../assets/images/others/blank-user.jpg';
  constructor(
    private router: Router,
    private employeesService: EmployeesService
  ) {}

  ngOnInit(): void {
    this.getEmployees();
  }

  addEmployee() {
    this.router.navigateByUrl('/employees/add');
  }

  getEmployees() {
    this.employeesService.getEmployees().subscribe((data) => {
      this.employees = data;
    });
  }

  editEmployee(id: any) {
    this.router.navigate(['/employees/edit', id]);
  }

  public createImageUrl = (imgSrc: string) => {
    if (imgSrc != null) {
      return MyConfig.address_server_base + imgSrc;
    }
    return this.imgSrc;
  };
}
