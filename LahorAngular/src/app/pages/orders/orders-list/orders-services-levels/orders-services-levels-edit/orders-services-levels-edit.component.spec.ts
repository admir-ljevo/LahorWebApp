import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdersServicesLevelsEditComponent } from './orders-services-levels-edit.component';

describe('OrdersServicesLevelsEditComponent', () => {
  let component: OrdersServicesLevelsEditComponent;
  let fixture: ComponentFixture<OrdersServicesLevelsEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrdersServicesLevelsEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdersServicesLevelsEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
