import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdersServicesLevelsAddComponent } from './orders-services-levels-add.component';

describe('OrdersServicesLevelsAddComponent', () => {
  let component: OrdersServicesLevelsAddComponent;
  let fixture: ComponentFixture<OrdersServicesLevelsAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrdersServicesLevelsAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdersServicesLevelsAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
