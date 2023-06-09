import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicesAddComponent } from './services-add.component';

describe('NewsAddComponent', () => {
  let component: ServicesAddComponent;
  let fixture: ComponentFixture<ServicesAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServicesAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServicesAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
