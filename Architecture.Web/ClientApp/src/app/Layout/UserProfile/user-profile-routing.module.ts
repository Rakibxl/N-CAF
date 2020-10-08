import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ViewProfileComponent } from './view-profile/view-profile.component';
import { ChangePasswordComponent } from './change-password/change-password.component';


const routes: Routes = [{
    path: '',
    children: [
        { path: '', redirectTo: 'dashboard' },
        { path: 'view', component: ViewProfileComponent },
        { path: 'change-password', component: ChangePasswordComponent }
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserProfileRoutingModule { }
