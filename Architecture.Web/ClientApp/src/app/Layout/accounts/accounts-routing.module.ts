import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountsHistoryComponent } from './accounts-history/accounts-history.component';


const routes: Routes = [
    {
        path: '',
        children: [
            { path: '', redirectTo: 'accounts-history' },
            { path: 'accounts-history', component: AccountsHistoryComponent, data: { extraParameter: 'dashboard' } },

        ]
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountsRoutingModule { }
