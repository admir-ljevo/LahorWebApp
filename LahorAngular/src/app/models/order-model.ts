export class OrderModel{
  id: number;
  name: string;
  delivered: boolean;
  deliveryDate: Date | null;
  price: number;
  description: string;
  clientName: string;
  online: boolean;
  employeeId: number;
  clientId: number;

  constructor() {
    this.id = 0;
    this.name = "";
    this.deliveryDate = null;
    this.delivered = false;
    this.price = 0;
    this.description = "";
    this.clientName = "";
    this.online = false;
    this.employeeId =+localStorage.getItem("user-id")!;
    this.clientId = 0;
  }
}
