import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OperatorAmountApprovalComponent } from './operator-amount-approval.component';

describe('OperatorAmountApprovalComponent', () => {
  let component: OperatorAmountApprovalComponent;
  let fixture: ComponentFixture<OperatorAmountApprovalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperatorAmountApprovalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OperatorAmountApprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
