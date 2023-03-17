import { Component, OnInit } from '@angular/core';
import {DeviceService} from "../../../services/DeviceService";
import {DeviceBrandService} from "../../../services/DeviceBrandService";
import {DeviceTypeService} from "../../../services/DeviceTypeService";
import {ActivatedRoute, Route, Router} from "@angular/router";
import {Observable} from "rxjs";

@Component({
  selector: 'app-device-edit',
  templateUrl: './device-edit.component.html',
  styleUrls: ['./device-edit.component.scss']
})
export class DeviceEditComponent implements OnInit {

  constructor(private deviceService: DeviceService,
              private deviceBrandService: DeviceBrandService,
              private deviceTypeService: DeviceTypeService,
              private router: Router,
              private route: ActivatedRoute) { }
  sub: any;
  private id: number;

  deviceBrands$!: Observable<any[]>;
  deviceBrands: any;
  deviceBrand: any;
  selectedDeviceBrandId: number = 0;

  deviceTypes$!: Observable<any[]>;
  deviceTypes: any;
  deviceType: any;
  selectedDeviceTypeId: number = 0;

  device$!: Observable<any>;
  device: any;

  ngOnInit(): void
  {
    this.sub = this.route.params.subscribe(params => {
      this.id=+params['id'];
    })
    this.getDeviceBrands();
    this.getDeviceTypes();
    this.getDevice();
  }

  getDevice() {
      this.device = this.deviceService.getById(this.id).subscribe((data :any) => {
      this.device = data;
      this.selectedDeviceBrandId = this.device.deviceBrandId;
      this.selectedDeviceTypeId = this.device.deviceTypeId;
    });
  }

  getDeviceTypes() {
    this.deviceTypes$ = this.deviceTypeService.getAll();
    this.deviceTypes$.subscribe((data: any) => {
      this.deviceTypes = data;
    });
  }

  getDeviceBrands() {
    this.deviceBrands$ = this.deviceBrandService.getAll();
    this.deviceBrands$.subscribe((data: any) => {
      this.deviceBrands = data;
    });
  }

  changeDeviceType(deviceType: any) {
    this.selectedDeviceTypeId = deviceType.id;
  }

  changeDeviceBrand(deviceBrand: any) {
    this.selectedDeviceBrandId = deviceBrand.id;
  }
  editDevice(){
    this.device.deviceBrandId = this.selectedDeviceBrandId;
    this.device.deviceTypeId = this.selectedDeviceTypeId;
    this.deviceService.update(this.device);
    this.router.navigateByUrl('device');
  }
}
