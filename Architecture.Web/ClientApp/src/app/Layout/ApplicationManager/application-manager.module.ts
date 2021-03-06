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
import { QuestionInformationComponent } from './question-information/question-information.component';
import { QuestionInformationFormComponent } from './question-information-form/question-information-form.component';
import { SectionLinkComponent } from './section-link/section-link.component';
import { SectionLinkFormComponent } from './section-link-form/section-link-form.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { NewKeywordComponent } from './application-user-form/new-keyword/new-keyword.component';

@NgModule({
  declarations: [ApplicationUserComponent, ApplicationUserRoleComponent, BranchInformationComponent, ApplicationAccessPermissionComponent, ApplicationUserFormComponent, BranchInformationFormComponent, ApplicationUserRoleFormComponent, ApplicationUserRoleMappingComponent, ApplicationUserRoleMappingFormComponent, QuestionInformationComponent, QuestionInformationFormComponent, SectionLinkComponent, SectionLinkFormComponent, NewKeywordComponent],
  imports: [
    CommonModule,
    SharedMasterModule,
    ApplicationManagerRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule
  ],
  entryComponents: [
    NewKeywordComponent
  ]
})
export class ApplicationManagerModule { }
