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
import { RolePermissions } from 'src/app/Shared/Constants/user-role-permission';
import { PermissionGuard } from 'src/app/Shared/Guards/permission.guard';

const routes: Routes = [
    {
        path: '',
        children: [
            // { path: '', redirectTo: 'branch-info' },
            {
                path: 'branch-info',
                component: BranchInformationComponent,
                canActivate: [PermissionGuard],
                data: { extraParameter: 'analytics', permissions: [RolePermissions.Branches.ListView] }
            },
            {
                path: 'branch-info/:id',
                component: BranchInformationFormComponent,
                canActivate: [PermissionGuard],
                data: { extraParameter: 'analytics', permissions: [RolePermissions.Branches.Create, RolePermissions.Branches.Edit] }
            },
            {
                path: 'user-info',
                component: ApplicationUserComponent,
                canActivate: [PermissionGuard],
                data: { extraParameter: 'analytics', permissions: [RolePermissions.Users.ListView] }
            },
            {
                path: 'user-info/:id',
                component: ApplicationUserFormComponent,
                canActivate: [PermissionGuard],
                data: { extraParameter: 'analytics', permissions: [RolePermissions.Users.Create, RolePermissions.Users.Edit] }
            },
            {
                path: 'user-role',
                component: ApplicationUserRoleComponent,
                canActivate: [PermissionGuard],
                data: { extraParameter: 'analytics', permissions: [RolePermissions.UserRoles.ListView] }
            },
            {
                path: 'user-role/:id',
                component: ApplicationUserRoleFormComponent,
                canActivate: [PermissionGuard],
                data: { extraParameter: 'analytics', permissions: [RolePermissions.UserRoles.Create, RolePermissions.UserRoles.Edit] }
            },
            {
                path: 'user-role-mapping',
                component: ApplicationUserRoleMappingComponent,
                canActivate: [PermissionGuard],
                data: { extraParameter: 'analytics', permissions: [RolePermissions.UserRoleMapping.ListView] }
            },
            {
                path: 'user-role-mapping/:id',
                component: ApplicationUserRoleMappingFormComponent,
                canActivate: [PermissionGuard],
                data: { extraParameter: 'analytics', permissions: [RolePermissions.UserRoleMapping.Create, RolePermissions.UserRoleMapping.Edit] }
            },
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