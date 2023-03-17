import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseRequestsListComponent } from './purchase-requests-list.component';

describe('PurchaseRequestsListComponent', () => {
  let component: PurchaseRequestsListComponent;
  let fixture: ComponentFixture<PurchaseRequestsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PurchaseRequestsListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseRequestsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
