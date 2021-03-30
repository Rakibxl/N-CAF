import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BranchUserDashboardComponent } from './branch-user-dashboard.component';

describe('BranchUserDashboardComponent', () => {
  let component: BranchUserDashboardComponent;
  let fixture: ComponentFixture<BranchUserDashboardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BranchUserDashboardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BranchUserDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
