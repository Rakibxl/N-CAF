import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserProfileRoutingModule } from './user-profile-routing.module';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { ViewProfileComponent } from './view-profile/view-profile.component';


@NgModule({
  declarations: [ChangePasswordComponent, ViewProfileComponent],
  imports: [
    CommonModule,
    UserProfileRoutingModule
  ]
})
export class UserProfileModule { }
