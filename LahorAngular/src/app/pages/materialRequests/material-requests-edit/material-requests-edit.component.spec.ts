import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaterialRequestsEditComponent } from './material-requests-edit.component';

describe('MaterialRequestsEditComponent', () => {
  let component: MaterialRequestsEditComponent;
  let fixture: ComponentFixture<MaterialRequestsEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MaterialRequestsEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MaterialRequestsEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
