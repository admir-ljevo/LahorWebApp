import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdersServicesLevelsListComponent } from './orders-services-levels-list.component';

describe('OrdersServicesLevelsListComponent', () => {
  let component: OrdersServicesLevelsListComponent;
  let fixture: ComponentFixture<OrdersServicesLevelsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrdersServicesLevelsListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdersServicesLevelsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
