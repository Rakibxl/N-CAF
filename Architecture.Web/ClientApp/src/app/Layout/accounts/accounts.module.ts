import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountsRoutingModule } from './accounts-routing.module';
import { AccountsHistoryComponent } from './accounts-history/accounts-history.component';


@NgModule({
  declarations: [AccountsHistoryComponent],
  imports: [
    CommonModule,
    AccountsRoutingModule
  ]
})
export class AccountsModule { }
