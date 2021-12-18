import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DodajObavijestComponent } from './dodaj-obavijest.component';

describe('DodajObavijestComponent', () => {
  let component: DodajObavijestComponent;
  let fixture: ComponentFixture<DodajObavijestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DodajObavijestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DodajObavijestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
