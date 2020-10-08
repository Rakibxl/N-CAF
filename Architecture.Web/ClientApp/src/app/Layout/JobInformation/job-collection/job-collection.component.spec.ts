import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JobCollectionComponent } from './job-collection.component';

describe('JobCollectionComponent', () => {
  let component: JobCollectionComponent;
  let fixture: ComponentFixture<JobCollectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JobCollectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JobCollectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
