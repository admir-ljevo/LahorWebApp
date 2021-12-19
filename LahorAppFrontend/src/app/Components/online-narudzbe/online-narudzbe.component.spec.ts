import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnlineNarudzbeComponent } from './online-narudzbe.component';

describe('OnlineNarudzbeComponent', () => {
  let component: OnlineNarudzbeComponent;
  let fixture: ComponentFixture<OnlineNarudzbeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OnlineNarudzbeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OnlineNarudzbeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
