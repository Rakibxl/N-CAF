import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PagesLayoutComponent } from './pages-layout.component';
import { ForgotPasswordBoxedComponent } from './forgot-password-boxed/forgot-password-boxed.component';
import { LoginBoxedComponent } from './login-boxed/login-boxed.component';
import { RegisterBoxedComponent } from './register-boxed/register-boxed.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { ForgotPasswordConfirmationBoxedComponent } from './forgot-password-confirmation-boxed/forgot-password-confirmation-boxed.component';
import { ResetPasswordBoxedComponent } from './reset-password-boxed/reset-password-boxed.component';
import { ResetPasswordConfirmationBoxedComponent } from './reset-password-confirmation-boxed copy/reset-password-confirmation-boxed.component';
import { LandingPageComponent } from './landing-page/landing-page.component';



const routes: Routes = [{
  path: '',
  component: PagesLayoutComponent,
  children: [
   { path: '', redirectTo:"landingpage"},
   { path: 'landingpage', component: LandingPageComponent, data: { extraParameter: 'dashboardsMenu'} },
   { path: 'forgot-password', component: ForgotPasswordBoxedComponent,data: {extraParameter: 'dashboardsMenu'} },
   { path: 'forgot-password-confirmation', component: ForgotPasswordConfirmationBoxedComponent,data: {extraParameter: 'dashboardsMenu'} },
   { path: 'reset-password', component: ResetPasswordBoxedComponent,data: {extraParameter: 'dashboardsMenu'} },
   { path: 'reset-password-confirmation', component: ResetPasswordConfirmationBoxedComponent,data: {extraParameter: 'dashboardsMenu'} },
   { path: 'login', component: LoginBoxedComponent,data: {extraParameter: 'dashboardsMenu'} },
   { path: 'register', component: RegisterBoxedComponent,data: {extraParameter: 'dashboardsMenu'} },
   { path: 'unauthorized', component: UnauthorizedComponent,data: {extraParameter: 'dashboardsMenu'} },
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OutsideLayoutRoutingModule { }
