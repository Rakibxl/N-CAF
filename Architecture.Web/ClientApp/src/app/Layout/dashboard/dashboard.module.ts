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


@NgModule({
  declarations: [
    CommonComponent   
  
  
  
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
DemoModule,
    NgSelectModule,
    
    DemoRoutingModule,
    SharedMasterModule,
    PerfectScrollbarModule,
     //Charts
    ChartsModule,
    AngularFontAwesomeModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HighchartsChartModule

  ]
})
export class DashboardModule { }
