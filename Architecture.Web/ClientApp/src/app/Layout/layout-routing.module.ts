import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BaseLayoutComponent } from './LayoutComponent/base-layout/base-layout.component';
import { AuthGuard } from '../Shared/Guards/auth.guard';

const routes: Routes = [
    {
        path: '',
        component: BaseLayoutComponent,
        canActivate: [AuthGuard],
        children: [
            { path: '', redirectTo: 'dashboard' },
            { path: 'demo', loadChildren: () => import('./DemoPages/demo.module').then(m => m.DemoModule) },
            { path: 'dashboard', loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule) },
            { path: 'users', loadChildren: () => import('./user/user.module').then(m => m.UserModule) },
            { path: 'roles', loadChildren: () => import('./user-role/user-role.module').then(m => m.UserRoleModule) },
            { path: 'examples', loadChildren: () => import('./examples/example.module').then(m => m.ExampleModule) },
            { path: 'client-profile', loadChildren: () => import('./ClientProfile/client-profle.module').then(m => m.ClientProfleModule) },
            { path: 'manager', loadChildren: () => import('./ApplicationManager/application-manager.module').then(m => m.ApplicationManagerModule) },
            { path: 'job-info', loadChildren: () => import('./JobInformation/job-information.module').then(m => m.JobInformationModule) },
            { path: 'generate-pdf', loadChildren: () => import('./generate-pdf/generate-pdf.module').then(m => m.GeneratePdfModule) },
            { path: 'accounts', loadChildren: () => import('./accounts/accounts.module').then(m => m.AccountsModule) },
            { path: 'profile', loadChildren: () => import('./UserProfile/user-profile.module').then(m => m.UserProfileModule) }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LayoutRoutingModule { }
