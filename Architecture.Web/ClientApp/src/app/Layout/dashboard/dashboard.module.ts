import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { CommonComponent } from './common/common.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { DemoRoutingModule } from '../DemoPages/demo-routing.module';
import { SharedMasterModule } from 'src/app/Shared/Modules/shared-master/shared-master.module';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { ChartsModule } from 'ng2-charts';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DemoModule } from '../DemoPages/demo.module';
import { HighchartsChartModule } from 'highcharts-angular';
import { JoblistComponent } from '../LayoutComponent/Components/joblist/joblist.component';
import { ProfileTreeComponent } from '../LayoutComponent/Components/profile-tree/profile-tree.component';
import { ChatBoxPopupComponent } from 'src/app/Shared/share-component/chat-box-popup/chat-box-popup.component';
import { CurrentOfferComponent } from '../dashboard/current-offer/current-offer.component';
import { OfferStatusComponent } from './offer-status/offer-status.component';
import { OfferHistoryComponent } from './offer-history/offer-history.component';
import { BranchUserDashboardComponent } from './branch-user-dashboard/branch-user-dashboard.component';
import { OperatorUserDashboardComponent } from './operator-user-dashboard/operator-user-dashboard.component';
import { ClientProfileCollectionComponent } from './client-profile-collection/client-profile-collection.component';
import { WaitingJobComponent } from './waiting-job/waiting-job.component';
import { PendingJobComponent } from './pending-job/pending-job.component';
import { CompletedJobComponent } from './completed-job/completed-job.component';
// import { SectionToSectionLinkComponent } from '../../Shared/share-component/section-to-section-link/section-to-section-link.component';



@NgModule({
  declarations: [
    CommonComponent,
    JoblistComponent,
    ProfileTreeComponent,
        ChatBoxPopupComponent,
        CurrentOfferComponent,
        OfferStatusComponent,
        OfferHistoryComponent,
        BranchUserDashboardComponent,
        OperatorUserDashboardComponent,
        ClientProfileCollectionComponent,
        WaitingJobComponent,
        PendingJobComponent,
        CompletedJobComponent
  ],

  imports: [
    CommonModule,
    DashboardRoutingModule,
    DemoModule,
    NgSelectModule,

    DemoRoutingModule,
    SharedMasterModule,
    PerfectScrollbarModule,
     // Charts
    ChartsModule,
    AngularFontAwesomeModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HighchartsChartModule

  ]
})
export class DashboardModule { }
