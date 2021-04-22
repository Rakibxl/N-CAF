import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JobNotificationHistoryComponent } from './job-notification-history.component';

describe('JobNotificationHistoryComponent', () => {
  let component: JobNotificationHistoryComponent;
  let fixture: ComponentFixture<JobNotificationHistoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JobNotificationHistoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JobNotificationHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
