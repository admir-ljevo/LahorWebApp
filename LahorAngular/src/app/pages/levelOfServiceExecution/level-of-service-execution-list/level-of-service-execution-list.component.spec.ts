import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LevelOfServiceExecutionListComponent } from './level-of-service-execution-list.component';

describe('LevelOfServiceExecutionListComponent', () => {
  let component: LevelOfServiceExecutionListComponent;
  let fixture: ComponentFixture<LevelOfServiceExecutionListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LevelOfServiceExecutionListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LevelOfServiceExecutionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
