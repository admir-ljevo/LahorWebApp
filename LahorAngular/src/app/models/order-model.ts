export class OrderModel{
  id: number;
  name: string;
  deliveryDate: Date;
  price: number;
  amount: number;
  description: string;
  clientName: string;
  online: boolean;
  employeeId: number;
  clientId: number;

  constructor() {
    this.id = 0;
    this.name = "";
    this.deliveryDate = new Date(Date.now());
    this.price = 0;
    this.amount = 0;
    this.description = "";
    this.clientName = "";
    this.online = false;
    this.employeeId =+localStorage.getItem("user-id")!;
    this.clientId =+localStorage.getItem("user-id")!;
  }
}
