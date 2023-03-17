import {Component, OnInit, TemplateRef} from '@angular/core';
import {DeviceService} from "../../../services/DeviceService";
import {Router} from "@angular/router";
import {Observable} from "rxjs";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrls: ['./device-list.component.scss']
})
export class DeviceListComponent implements OnInit {

  constructor(private deviceService: DeviceService, private router: Router, private modalService: NgbModal) { }
  devices$: Observable<any[]>
  changeDirection: boolean = false;
  sortDir: string = "asc";
  sortCol: string = "deviceBrand.Name";
  selectedDevice: any;
  basicModalCloseResult: string = '';
  tableHeaders: any [];

  ngOnInit(): void {
    this.getAllDevices();
  }

  sortData(event: Event){
    this.sortCol === (event.target as Element).id? this.changeDirection=true: this.changeDirection=false;
    this.sortCol = (event.target as Element).id;
    if(this.changeDirection && this.sortDir==="asc")
      this.sortDir="desc"
   else if(this.changeDirection && this.sortDir==="desc")
      this.sortDir="asc";
   else this.sortDir="asc";
    const tableHeader = document.getElementById((event.target as Element).id);
    const tableHeaders = document.getElementsByTagName("th");
    // @ts-ignore
    for (const th of tableHeaders) {
      if(th.id != (event.target as Element).id)
      th.style.color="gray";
    }
    // @ts-ignore
    tableHeader.style.color='#4e42f7';
      this.getAllDevices();

  }
  getAllDevices() {
    this.devices$ = this.deviceService.getDevicesSorted(this.sortCol, this.sortDir);
  }

  addDevice() {
    this.router.navigateByUrl('device/add-device');
  }

  editDevice(x: any) {
    this.router.navigate(['device/edit-device', x.id]);
  }
  openBasicModal(content: TemplateRef<any>,x:any){
    this.selectedDevice = x;
    this.modalService.open(content, {}).result.then((result:any) => {
      this.basicModalCloseResult = "Modal closed" + result
    }).catch((res:any)=>console.log(res));
  }

  deleteDevice(modal: any) {
    this.deviceService.delete(this.selectedDevice).subscribe(data=> {
      this.getAllDevices()
    });
    modal.close('by: save button');
  }
}
