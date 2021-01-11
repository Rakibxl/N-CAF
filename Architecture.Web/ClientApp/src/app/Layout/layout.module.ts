import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
// import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {NgReduxModule} from '@angular-redux/store';
import {NgRedux, DevToolsExtension} from '@angular-redux/store';
// import {rootReducer, ArchitectUIState} from './ThemeOptions/store';
// import {ConfigActions} from './ThemeOptions/store/config.actions';

import {CommonModule} from '@angular/common';
import {HttpClientModule} from '@angular/common/http';

// BOOTSTRAP COMPONENTS

import {AngularFontAwesomeModule} from 'angular-font-awesome';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {PerfectScrollbarModule} from 'ngx-perfect-scrollbar';
import {PERFECT_SCROLLBAR_CONFIG} from 'ngx-perfect-scrollbar';
import {PerfectScrollbarConfigInterface} from 'ngx-perfect-scrollbar';

import {LoadingBarRouterModule} from '@ngx-loading-bar/router';

import { LayoutRoutingModule } from './layout-routing.module';


// LAYOUT

import { BaseLayoutComponent } from './LayoutComponent/base-layout/base-layout.component';
//import { PageTitleComponent } from './LayoutComponent/Components/page-title/page-title.component';

// HEADER

import { HeaderComponent } from './LayoutComponent/Components/header/header.component';
import { SearchBoxComponent } from './LayoutComponent/Components/header/elements/search-box/search-box.component';
import { UserBoxComponent } from './LayoutComponent/Components/header/elements/user-box/user-box.component';

// SIDEBAR

import { SidebarComponent } from './LayoutComponent/Components/sidebar/sidebar.component';
import { LogoComponent } from './LayoutComponent/Components/sidebar/elements/logo/logo.component';

// FOOTER

import { FooterComponent } from './LayoutComponent/Components/footer/footer.component';
import { SharedMasterModule } from '../Shared/Modules/shared-master/shared-master.module';
import { HeaderNotificationComponent } from './LayoutComponent/Components/header/elements/header-notification/header-notification.component';

import { NgSelectModule } from '@ng-select/ng-select';
//import { CurrentOfferComponent } from './LayoutComponent/Components/current-offer/current-offer.component';
import { OfferHistoryComponent } from './LayoutComponent/Components/offer-history/offer-history.component';
import { LanguageChangeComponent } from './LayoutComponent/Components/header/elements/language-change/language-change.component';
//import { UserInfoListComponent } from './user-info/user-info-list/user-info-list.component';
//import { UserInfoInsertComponent } from './user-info/user-info-insert/user-info-insert.component';
//import { UserInfoComponent } from './user-details/user-info/user-info.component';
//import { UserListComponent } from './user-details/user-list/user-list.component';

// import { UserListComponent } from './azure-ad/user-list/user-list.component';




@NgModule({
  declarations: [
    
    // LAYOUT
    BaseLayoutComponent,
    //PageTitleComponent,

    // HEADER

    HeaderComponent,
    SearchBoxComponent,
    UserBoxComponent,

    // SIDEBAR

    SidebarComponent,
    LogoComponent,

    // FOOTER


    FooterComponent,

    //UserInfoListComponent,
    FooterComponent,

    HeaderNotificationComponent,

    //CurrentOfferComponent,

    OfferHistoryComponent,

    LanguageChangeComponent,   

  ],
  imports: [
    CommonModule,
    LoadingBarRouterModule,
    LayoutRoutingModule,
    NgReduxModule,

    // Angular Bootstrap Components

    PerfectScrollbarModule,
    NgbModule,
    AngularFontAwesomeModule,
    FormsModule,
      ReactiveFormsModule,
      NgSelectModule,
    // HttpClientModule,
    SharedMasterModule,
  ]
})
export class LayoutModule { }
