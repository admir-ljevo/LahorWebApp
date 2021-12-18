import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PregledEditObavijestiComponent } from './pregled-edit-obavijesti.component';

describe('PregledEditObavijestiComponent', () => {
  let component: PregledEditObavijestiComponent;
  let fixture: ComponentFixture<PregledEditObavijestiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PregledEditObavijestiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PregledEditObavijestiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
