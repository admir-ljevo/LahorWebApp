import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UspjesnaRegistracijaComponent } from './uspjesna-registracija.component';

describe('UspjesnaRegistracijaComponent', () => {
  let component: UspjesnaRegistracijaComponent;
  let fixture: ComponentFixture<UspjesnaRegistracijaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UspjesnaRegistracijaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UspjesnaRegistracijaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
