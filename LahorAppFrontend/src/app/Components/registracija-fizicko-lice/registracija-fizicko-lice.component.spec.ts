import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistracijaFizickoLiceComponent } from './registracija-fizicko-lice.component';

describe('RegistracijaFizickoLiceComponent', () => {
  let component: RegistracijaFizickoLiceComponent;
  let fixture: ComponentFixture<RegistracijaFizickoLiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegistracijaFizickoLiceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistracijaFizickoLiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
