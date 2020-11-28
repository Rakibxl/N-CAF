import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OccupationHistoryFormComponent } from './occupation-history-form.component';

describe('OccupationHistoryFormComponent', () => {
    let component: OccupationHistoryFormComponent;
    let fixture: ComponentFixture<OccupationHistoryFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
        declarations: [OccupationHistoryFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
      fixture = TestBed.createComponent(OccupationHistoryFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
