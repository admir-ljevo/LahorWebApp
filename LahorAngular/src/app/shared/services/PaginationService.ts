import { Injectable, OnInit } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PaginationService implements OnInit {
  itemsPerPage: any = [];
  constructor() {
    this.itemsPerPage = [5, 10, 15, 20, 50, 100];
  }

  ngOnInit(): void {}

  getCollectionSize(pageSize: any, totalRecordsCount: any) {
    if (totalRecordsCount === 0) return 0;
    return (10 / pageSize) * totalRecordsCount;
  }

  getItemsPerPage() {
    return this.itemsPerPage;
  }
}
