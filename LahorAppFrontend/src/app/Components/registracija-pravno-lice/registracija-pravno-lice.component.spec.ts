import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistracijaPravnoLiceComponent } from './registracija-pravno-lice.component';

describe('RegistracijaPravnoLiceComponent', () => {
  let component: RegistracijaPravnoLiceComponent;
  let fixture: ComponentFixture<RegistracijaPravnoLiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegistracijaPravnoLiceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistracijaPravnoLiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
