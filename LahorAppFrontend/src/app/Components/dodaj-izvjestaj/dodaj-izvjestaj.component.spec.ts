import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DodajIzvjestajComponent } from './dodaj-izvjestaj.component';

describe('DodajIzvjestajComponent', () => {
  let component: DodajIzvjestajComponent;
  let fixture: ComponentFixture<DodajIzvjestajComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DodajIzvjestajComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DodajIzvjestajComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
