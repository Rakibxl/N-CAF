import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountsRoutingModule } from './accounts-routing.module';
import { AccountsHistoryComponent } from './accounts-history/accounts-history.component';
import { RechargeMoneyComponent } from './recharge-money/recharge-money.component';
import { RechargeApprovalComponent } from './recharge-approval/recharge-approval.component';
import { AccountInfoListComponent } from './account-info-list/account-info-list.component';


@NgModule({
  declarations: [AccountsHistoryComponent, RechargeMoneyComponent, RechargeApprovalComponent, AccountInfoListComponent],
  imports: [
    CommonModule,
    AccountsRoutingModule
  ]
})
export class AccountsModule { }
