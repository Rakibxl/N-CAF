import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserProfileRoutingModule } from './user-profile-routing.module';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { ViewProfileComponent } from './view-profile/view-profile.component';
import { SharedMasterModule } from '../../Shared/Modules/shared-master/shared-master.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NotificationDetailsComponent } from './notification-details/notification-details.component';


@NgModule({
  declarations: [ChangePasswordComponent, ViewProfileComponent, NotificationDetailsComponent],
  imports: [
    CommonModule,
      UserProfileRoutingModule,
      FormsModule,
      ReactiveFormsModule,
      NgSelectModule,
      SharedMasterModule,
  ]
})
export class UserProfileModule { }
