import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BranchUserDashboardComponent } from './branch-user-dashboard/branch-user-dashboard.component';
import { CommonComponent } from './common/common.component';
import { OperatorUserDashboardComponent } from './operator-user-dashboard/operator-user-dashboard.component';


const routes: Routes = [
  {
    path: '',
        children: [
            { path: '', redirectTo: 'common', pathMatch:'full' },
        { path: 'common', component: CommonComponent, data: { extraParameter: 'dashboard' } },
        { path: 'common/:profId', component: CommonComponent, data: { extraParameter: 'dashboard' } },
        { path: 'branch-user', component: BranchUserDashboardComponent, data: { extraParameter: 'dashboard' } },
        { path: 'operator', component: OperatorUserDashboardComponent, data: { extraParameter: 'dashboard' } },
       
    ]
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
