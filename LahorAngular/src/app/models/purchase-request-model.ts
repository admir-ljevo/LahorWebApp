export class PurchaseRequestModel{
  id: number;
  name: string;
  description: string;
  isCompleted: boolean;
  datePurchased: Date | null;
  price: number;
  employeeId: number;

  constructor() {
    this.id = 0;
    this.name = "";
    this.price = 0;
    this.description = "";
    this.isCompleted = false;
    this.datePurchased = null
    this.employeeId =+localStorage.getItem("user-id")!;
  }

}
