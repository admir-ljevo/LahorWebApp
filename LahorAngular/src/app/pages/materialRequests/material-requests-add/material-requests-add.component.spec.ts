import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaterialRequestsAddComponent } from './material-requests-add.component';

describe('MaterialRequestsAddComponent', () => {
  let component: MaterialRequestsAddComponent;
  let fixture: ComponentFixture<MaterialRequestsAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MaterialRequestsAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MaterialRequestsAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
