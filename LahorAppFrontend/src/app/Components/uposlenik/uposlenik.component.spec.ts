import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UposlenikComponent } from './uposlenik.component';

describe('UposlenikComponent', () => {
  let component: UposlenikComponent;
  let fixture: ComponentFixture<UposlenikComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UposlenikComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UposlenikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
