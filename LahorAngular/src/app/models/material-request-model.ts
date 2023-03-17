export class MaterialRequestModel{
  id: number;
  purchaseRequestId: number;
  materialId: number;
  unitPrice: number;
  amount: number;
  totalPrice: number;

  constructor() {
    this.id = 0;
    this.purchaseRequestId = 0;
    this.materialId = 0;
    this.unitPrice = 0;
    this.amount = 1;
    this.totalPrice = 0;
  }
}
