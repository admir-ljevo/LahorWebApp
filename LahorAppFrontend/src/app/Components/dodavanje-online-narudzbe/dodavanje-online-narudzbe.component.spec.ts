import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DodavanjeOnlineNarudzbeComponent } from './dodavanje-online-narudzbe.component';

describe('DodavanjeOnlineNarudzbeComponent', () => {
  let component: DodavanjeOnlineNarudzbeComponent;
  let fixture: ComponentFixture<DodavanjeOnlineNarudzbeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DodavanjeOnlineNarudzbeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DodavanjeOnlineNarudzbeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
