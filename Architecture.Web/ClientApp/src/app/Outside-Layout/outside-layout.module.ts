import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {LoadingBarRouterModule} from '@ngx-loading-bar/router';
import { OutsideLayoutRoutingModule } from './outside-layout-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
// // Pages

import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';

import { ForgotPasswordBoxedComponent } from './forgot-password-boxed/forgot-password-boxed.component';
import { LoginBoxedComponent } from './login-boxed/login-boxed.component';
import { RegisterBoxedComponent } from './register-boxed/register-boxed.component';
import { PagesLayoutComponent } from './pages-layout.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ForgotPasswordConfirmationBoxedComponent } from './forgot-password-confirmation-boxed/forgot-password-confirmation-boxed.component';
import { ResetPasswordBoxedComponent } from './reset-password-boxed/reset-password-boxed.component';
import { ResetPasswordConfirmationBoxedComponent } from './reset-password-confirmation-boxed copy/reset-password-confirmation-boxed.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { UserLoginComponent } from './user-login/user-login.component';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { RightSitePanelComponent } from './right-site-panel/right-site-panel.component';
import { UnauthSlideComponent } from './unauth-slide/unauth-slide.component';
import { TopOffersComponent } from './top-offers/top-offers.component';
import { BannerSliderComponent } from './banner-slider/banner-slider.component';
import { SharedMasterModule } from '../Shared/Modules/shared-master/shared-master.module';

@NgModule({
  declarations: [
    PagesLayoutComponent,
    ForgotPasswordBoxedComponent,
    LoginBoxedComponent,
    RegisterBoxedComponent,
    UnauthorizedComponent,
    ForgotPasswordConfirmationBoxedComponent,
    ResetPasswordBoxedComponent,
    ResetPasswordConfirmationBoxedComponent,
    LandingPageComponent,
    UserLoginComponent,
    UserRegistrationComponent,
    RightSitePanelComponent,
    UnauthSlideComponent,
    TopOffersComponent,
    BannerSliderComponent,
  ],
  imports: [
    CommonModule,
    OutsideLayoutRoutingModule,
    LoadingBarRouterModule,
    PerfectScrollbarModule,
    FormsModule,
    NgbModule,
      ReactiveFormsModule,
      SharedMasterModule
  ]
})
export class OutsideLayoutModule { }
