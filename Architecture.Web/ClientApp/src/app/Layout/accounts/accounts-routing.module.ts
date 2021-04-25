import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountInfoListComponent } from './account-info-list/account-info-list.component';
import { AccountsHistoryComponent } from './accounts-history/accounts-history.component';
import { RechargeApprovalComponent } from './recharge-approval/recharge-approval.component';
import { RechargeMoneyComponent } from './recharge-money/recharge-money.component';


const routes: Routes = [
    {
        path: '',
        children: [
            { path: '', redirectTo: 'accounts-history' },
            { path: 'accounts-info', component: AccountInfoListComponent, data: { extraParameter: 'dashboard' } },
            { path: 'accounts-history', component: AccountsHistoryComponent, data: { extraParameter: 'dashboard' } },
            { path: 'recharge-approval', component: RechargeApprovalComponent, data: { extraParameter: 'dashboard' } },
            { path: 'recharge-request', component: RechargeMoneyComponent, data: { extraParameter: 'dashboard' } },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AccountsRoutingModule { }
