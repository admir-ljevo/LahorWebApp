import { Component, OnInit } from '@angular/core';
import { ServicesService } from '../../../services/ServicesService';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { TypeOfServicesService } from '../../../services/TypeOfServicesService';

@Component({
  selector: 'app-price-list-preview',
  templateUrl: './price-list-preview.component.html',
  styleUrls: ['./price-list-preview.component.scss'],
})
export class PriceListPreviewComponent implements OnInit {
  services$!: Observable<any[]>;
  typeOfServices: any;
  services: any;

  constructor(
    private servicesService: ServicesService,
    private typeOfServicesService: TypeOfServicesService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.typeOfServicesService.getAll().subscribe((data: any) => {
      this.typeOfServices = data;
    });
  }
}
