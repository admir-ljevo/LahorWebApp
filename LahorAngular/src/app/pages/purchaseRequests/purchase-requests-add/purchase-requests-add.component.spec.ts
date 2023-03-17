import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseRequestsAddComponent } from './purchase-requests-add.component';

describe('PurchaseRequestsAddComponent', () => {
  let component: PurchaseRequestsAddComponent;
  let fixture: ComponentFixture<PurchaseRequestsAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PurchaseRequestsAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseRequestsAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
