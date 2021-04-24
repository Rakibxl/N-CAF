import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RechargeMoneyComponent } from './recharge-money.component';

describe('RechargeMoneyComponent', () => {
  let component: RechargeMoneyComponent;
  let fixture: ComponentFixture<RechargeMoneyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RechargeMoneyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RechargeMoneyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
