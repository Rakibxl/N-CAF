import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OperatorUserDashboardComponent } from './operator-user-dashboard.component';

describe('OperatorUserDashboardComponent', () => {
  let component: OperatorUserDashboardComponent;
  let fixture: ComponentFixture<OperatorUserDashboardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperatorUserDashboardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OperatorUserDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
