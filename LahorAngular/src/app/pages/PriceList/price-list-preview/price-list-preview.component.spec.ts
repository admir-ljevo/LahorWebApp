import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PriceListPreviewComponent } from './price-list-preview.component';

describe('PriceListPreviewComponent', () => {
  let component: PriceListPreviewComponent;
  let fixture: ComponentFixture<PriceListPreviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PriceListPreviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PriceListPreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
