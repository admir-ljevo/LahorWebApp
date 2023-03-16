export class OrderServicesLevels{
  orderId: number;
  serviceId: number;
  levelOfServiceExecutionId: number;
  unitPrice: number;
  totalPrice: number;
  amount: number;

  constructor() {
    this.orderId=0;
    this.serviceId=0;
    this.levelOfServiceExecutionId=0;
    this.unitPrice = 0;
    this.totalPrice = 0;
    this.amount = 1;
  }
}
