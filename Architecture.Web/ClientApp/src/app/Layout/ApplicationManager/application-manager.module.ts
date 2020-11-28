import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ApplicationManagerRoutingModule } from './application-manager-routing.module';
import { ApplicationUserComponent } from './application-user/application-user.component';
import { ApplicationUserRoleComponent } from './application-user-role/application-user-role.component';
import { BranchInformationComponent } from './branch-information/branch-information.component';
import { ApplicationAccessPermissionComponent } from './application-access-permission/application-access-permission.component';
import { ApplicationUserFormComponent } from './application-user-form/application-user-form.component';
import { BranchInformationFormComponent } from './branch-information-form/branch-information-form.component';
import { ApplicationUserRoleFormComponent } from './application-user-role-form/application-user-role-form.component';
import { ApplicationUserRoleMappingComponent } from './application-user-role-mapping/application-user-role-mapping.component';
import { SharedMasterModule } from '../../Shared/Modules/shared-master/shared-master.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApplicationUserRoleMappingFormComponent } from './application-user-role-mapping-form/application-user-role-mapping-form.component';

@NgModule({
  declarations: [ApplicationUserComponent, ApplicationUserRoleComponent, BranchInformationComponent, ApplicationAccessPermissionComponent, ApplicationUserFormComponent, BranchInformationFormComponent, ApplicationUserRoleFormComponent, ApplicationUserRoleMappingComponent, ApplicationUserRoleMappingFormComponent],
  imports: [
    CommonModule,
    SharedMasterModule,
    ApplicationManagerRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class ApplicationManagerModule { }
