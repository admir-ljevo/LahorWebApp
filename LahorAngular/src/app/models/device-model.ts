export class DeviceModel{
  id: number;
  name: string;
  deviceBrandId: number;
  deviceTypeId: number;
  description: string;
  capacity: number;
  serviceDate: Date;

  constructor() {
    this.id = 0;
    this.name = "";
    this.deviceBrandId = 0;
    this.deviceTypeId = 0;
    this.description = "";
    this.capacity = 0;
    this.serviceDate = new Date(Date.now());

  }

}
