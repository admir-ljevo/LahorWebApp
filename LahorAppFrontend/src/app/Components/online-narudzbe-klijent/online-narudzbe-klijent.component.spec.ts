import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnlineNarudzbeKlijentComponent } from './online-narudzbe-klijent.component';

describe('OnlineNarudzbeKlijentComponent', () => {
  let component: OnlineNarudzbeKlijentComponent;
  let fixture: ComponentFixture<OnlineNarudzbeKlijentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OnlineNarudzbeKlijentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OnlineNarudzbeKlijentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
