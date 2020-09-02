import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DemoRoutingModule } from './demo-routing.module';
import { AnalyticsComponent } from './Dashboards/analytics/analytics.component';
import { AccordionsComponent } from './Components/accordions/accordions.component';
import { TabsComponent } from './Components/tabs/tabs.component';
import { CarouselComponent } from './Components/carousel/carousel.component';
import { ModalsComponent } from './Components/modals/modals.component';
import { ProgressBarComponent } from './Components/progress-bar/progress-bar.component';
import { PaginationComponent } from './Components/pagination/pagination.component';
import { TooltipsPopoversComponent } from './Components/tooltips-popovers/tooltips-popovers.component';
import { RegularComponent } from './Tables/regular/regular.component';
import { TablesMainComponent } from './Tables/tables-main/tables-main.component';
import { ChartBoxes3Component } from './Widgets/chart-boxes3/chart-boxes3.component';
import { ControlsComponent } from './Forms/Elements/controls/controls.component';
import { LayoutComponent } from './Forms/Elements/layout/layout.component';
import { ChartjsComponent } from './Charts/chartjs/chartjs.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SharedMasterModule } from 'src/app/Shared/Modules/shared-master/shared-master.module';
import { ChartsModule } from 'ng2-charts';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { ExampleFormValidationComponent } from './example-form-validation/example-form-validation.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { AlertDemoComponent } from './alert-demo/alert-demo.component';
import { DataTableComponent } from './data-table/data-table.component';
import { TestCompComponent } from './test-comp/test-comp.component';
@NgModule({
  declarations: [
    AnalyticsComponent,
    //Components
    AccordionsComponent,
    TabsComponent,
    CarouselComponent,
    ModalsComponent,
    ProgressBarComponent,
    PaginationComponent,
    TooltipsPopoversComponent,
    //Tables
    RegularComponent,
    TablesMainComponent,
    // Widgets
    ChartBoxes3Component,
    // Forms Elements
    ControlsComponent,
    LayoutComponent,

    // // Charts
    ChartjsComponent,
    FetchDataComponent,
    ExampleFormValidationComponent,
    AlertDemoComponent,
    DataTableComponent,
    TestCompComponent

  ],
  imports: [
    NgSelectModule,
    CommonModule,
    DemoRoutingModule,
    SharedMasterModule,
    PerfectScrollbarModule,
     //Charts
    ChartsModule,
    AngularFontAwesomeModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule

  ]
})
export class DemoModule { }
