import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LevelOfServiceExecutionAddComponent } from './level-of-service-execution-add.component';

describe('LevelOfServiceExecutionAddComponent', () => {
  let component: LevelOfServiceExecutionAddComponent;
  let fixture: ComponentFixture<LevelOfServiceExecutionAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LevelOfServiceExecutionAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LevelOfServiceExecutionAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
