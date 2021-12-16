import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpravnoOsobljeComponent } from './upravno-osoblje.component';

describe('UpravnoOsobljeComponent', () => {
  let component: UpravnoOsobljeComponent;
  let fixture: ComponentFixture<UpravnoOsobljeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpravnoOsobljeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpravnoOsobljeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
