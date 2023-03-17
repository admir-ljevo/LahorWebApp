import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseRequestsEditComponent } from './purchase-requests-edit.component';

describe('PurchaseRequestsEditComponent', () => {
  let component: PurchaseRequestsEditComponent;
  let fixture: ComponentFixture<PurchaseRequestsEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PurchaseRequestsEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseRequestsEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
