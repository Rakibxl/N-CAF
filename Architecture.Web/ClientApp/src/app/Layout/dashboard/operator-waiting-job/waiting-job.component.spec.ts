import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WaitingJobComponent } from './waiting-job.component';

describe('WaitingJobComponent', () => {
  let component: WaitingJobComponent;
  let fixture: ComponentFixture<WaitingJobComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WaitingJobComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WaitingJobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
