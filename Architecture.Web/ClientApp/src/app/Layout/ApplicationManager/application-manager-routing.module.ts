import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BranchInformationComponent } from './branch-information/branch-information.component';
import { ApplicationUserComponent } from './application-user/application-user.component';
import { ApplicationUserRoleComponent } from './application-user-role/application-user-role.component';
import { ApplicationUserFormComponent } from './application-user-form/application-user-form.component';
import { ApplicationUserRoleFormComponent } from './application-user-role-form/application-user-role-form.component';
import { BranchInformationFormComponent } from './branch-information-form/branch-information-form.component';
import { ApplicationUserRoleMappingComponent } from './application-user-role-mapping/application-user-role-mapping.component';
import { ApplicationUserRoleMappingFormComponent } from './application-user-role-mapping-form/application-user-role-mapping-form.component';
import { ApplicationAccessPermissionComponent } from './application-access-permission/application-access-permission.component';
import { QuestionInformationComponent } from './question-information/question-information.component';
import { QuestionInformationFormComponent } from './question-information-form/question-information-form.component';
import { SectionLinkComponent } from './section-link/section-link.component';
import { SectionLinkFormComponent } from './section-link-form/section-link-form.component';

const routes: Routes = [
    {
        path: '',
        children: [
            // { path: '', redirectTo: 'branch-info' },
            { path: 'branch-info/:id', component: BranchInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'branch-info', component: BranchInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'user-info/:id', component: ApplicationUserFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'user-info', component: ApplicationUserComponent, data: { extraParameter: 'analytics' } },
            { path: 'user-role/:id', component: ApplicationUserRoleFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'user-role', component: ApplicationUserRoleComponent, data: { extraParameter: 'analytics' } },
            { path: 'user-role-mapping', component: ApplicationUserRoleMappingComponent, data: { extraParameter: 'analytics' } },
            { path: 'user-role-mapping/:id', component: ApplicationUserRoleMappingFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'access-permission', component: ApplicationAccessPermissionComponent, data: { extraParameter: 'analytics' } },
            { path: 'question-info', component: QuestionInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'question-info/:id', component: QuestionInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'section-link', component: SectionLinkComponent, data: { extraParameter: 'analytics' } },
            { path: 'section-link/:id', component: SectionLinkFormComponent, data: { extraParameter: 'analytics' } }

        ]
    }
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ApplicationManagerRoutingModule { }