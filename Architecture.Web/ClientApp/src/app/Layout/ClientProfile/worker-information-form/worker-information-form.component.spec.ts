import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkerInformationFormComponent } from './worker-information-form.component';

describe('WorkerInformationFormComponent', () => {
  let component: WorkerInformationFormComponent;
  let fixture: ComponentFixture<WorkerInformationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkerInformationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkerInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
