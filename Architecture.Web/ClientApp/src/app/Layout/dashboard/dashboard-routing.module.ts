import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BranchUserDashboardComponent } from './branch-user-dashboard/branch-user-dashboard.component';
import { CommonComponent } from './common/common.component';
import { OperatorUserDashboardComponent } from './operator-user-dashboard/operator-user-dashboard.component';
import {DashboardGuard} from '../../Shared/Guards/dashboard.guard';


const routes: Routes = [
  {
    path: '',
        children: [
            { path: '', pathMatch:'full',
            canActivate: [DashboardGuard]},
        { path: 'common',
            component: CommonComponent, data: { extraParameter: 'dashboard' },
        },
        { path: 'common/:profId', component: CommonComponent, data: { extraParameter: 'dashboard' } },
        { path: 'branch-user', component: BranchUserDashboardComponent, data: { extraParameter: 'dashboard' },
            canActivate: [DashboardGuard]},
        { path: 'operator', component: OperatorUserDashboardComponent, data: { extraParameter: 'dashboard' },
            canActivate: [DashboardGuard]},
    ]
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
