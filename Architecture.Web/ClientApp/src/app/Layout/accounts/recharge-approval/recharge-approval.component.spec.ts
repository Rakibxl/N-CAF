import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RechargeApprovalComponent } from './recharge-approval.component';

describe('RechargeApprovalComponent', () => {
  let component: RechargeApprovalComponent;
  let fixture: ComponentFixture<RechargeApprovalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RechargeApprovalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RechargeApprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
