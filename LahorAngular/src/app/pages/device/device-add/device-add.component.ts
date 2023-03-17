import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {DeviceService} from "../../../services/DeviceService";
import {DeviceBrandService} from "../../../services/DeviceBrandService";
import {DeviceTypeService} from "../../../services/DeviceTypeService";
import {Router} from "@angular/router";
import {Observable} from "rxjs";
import {DeviceModel} from "../../../models/device-model";

@Component({
  selector: 'app-device-add',
  templateUrl: './device-add.component.html',
  styleUrls: ['./device-add.component.scss']
})
export class DeviceAddComponent implements OnInit {
  deviceBrands$!:Observable<any[]>;
  deviceBrands: any;
  deviceBrand: any;
  selectedDeviceBrandId: number = 0;
  deviceTypes$!:Observable<any[]>;
  deviceTypes: any;
  deviceType: any;
  selectedDeviceTypeId: number = 0;

  device: DeviceModel = new DeviceModel();




  constructor(private httpClient: HttpClient, private deviceService: DeviceService, private deviceBrandService: DeviceBrandService, private  deviceTypeService: DeviceTypeService, private  router: Router) { }

  ngOnInit(): void {
    this.getDeviceBrands();
    this.getDeviceTypes();
  }

  getDeviceBrands() {
    this.deviceBrands$ = this.deviceBrandService.getAll();
    this.deviceBrands$.subscribe((data: any) => {
      this.deviceBrands = data

    });
  }

  getDeviceTypes() {
    this.deviceTypes$ = this.deviceTypeService.getAll();
    this.deviceTypes$.subscribe((data: any) => {
      this.deviceTypes = data
    });
  }


  changeDeviceBrand(deviceBrand: any) {
    this.selectedDeviceBrandId = deviceBrand.id;
  }

  changeDeviceType(deviceType: any) {
    this.selectedDeviceTypeId = deviceType.id;
  }

  addDevice(){
    this.device.deviceTypeId = this.selectedDeviceTypeId;
    this.device.deviceBrandId = this.selectedDeviceBrandId;
    this.deviceService.post(this.device).subscribe(data => {
      this.router.navigateByUrl('device');
    })

    }

}
