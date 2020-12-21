import { Component, OnInit } from '@angular/core';
import { Color } from 'ng2-charts';
import { DashboardService } from 'src/app/Shared/Services/Dashboard/dashboard.service';
import { AlertService } from 'src/app/Shared/Modules/alert/alert.service';
import { Router } from '@angular/router';
import { Dashboard } from 'src/app/Shared/Entity/Common/dashboard';
import * as Highcharts from 'highcharts';

@Component({
  selector: 'app-common',
  templateUrl: './common.component.html',
  styleUrls: ['./common.component.css']
})
export class CommonComponent implements OnInit {

  dashboard : Dashboard = new Dashboard();
  Highcharts: typeof Highcharts = Highcharts; // required
  chartConstructor: string = 'chart'; // optional string, defaults to 'chart'
  serviceRequestChartOptions: Highcharts.Options = { 
    chart: {
      type: 'column'
    },
    credits: {
      enabled: false
    },
    title: {
      text: 'Graphical Presentation for Last 30 days'
    },
    legend: {
      align: 'center',
      verticalAlign: 'top',
      layout: 'vertical',
    },
    xAxis: {
      categories: []
    },
    yAxis: {
      allowDecimals: false,
      title: { text: '' }
    },
    series: [{
      name: 'Number of Service Request',
      type: 'column',
      data: [],
      color: "rgba(1, 183, 230, 0.4)",
      borderColor: "rgba(1, 183, 230, 0.4)",
      borderWidth: 2
    }]
   }; // required
   newAppUserRegisterChartOptions: Highcharts.Options = { 
    chart: {
      type: 'column'
    },
    credits: {
      enabled: false
    },
    title: {
      text: 'Graphical Presentation for Last 30 days'
    },
    legend: {
      align: 'center',
      verticalAlign: 'top',
      layout: 'vertical',
    },
    xAxis: {
      categories: []
    },
    yAxis: {
      allowDecimals: false,
      title: { text: '' }
    },
    series: [{
      name: 'Number of App User Registration',
      type: 'column',
      data: [],
      color: "rgba(1, 183, 230, 0.4)",
      borderColor: "rgba(1, 183, 230, 0.4)",
      borderWidth: 2
    }]
   }; // required
  chartCallback: Highcharts.ChartCallbackFunction = function (chart) {  } // optional function, defaults to null
  updateFlag: boolean = false; // optional boolean
  oneToOneFlag: boolean = true; // optional boolean, defaults to false
  runOutsideAngular: boolean = false;
  

  constructor(private dashboardService: DashboardService,
    private alertService: AlertService,
    private router: Router
    ) { }

  ngOnInit() {
    //this.dashboardService.getDashboardData()
    //  .subscribe(res => {
    //    this.dashboard = res.data;
    //    console.log(`dashboard response - ${JSON.stringify(res)}`);
    //    this.generateChart();
    //  });
  }

  generateChart() {
    //#region new user chart
    const newUsersCat = this.dashboard.newAppUserRegisterCharts.map(x => x.dateTimeText) as [];
    const newUsersData = this.dashboard.newAppUserRegisterCharts.map(x => x.totalAppRegisterUser) as [];

    const newUserXAxis: Highcharts.XAxisOptions = {
      categories: newUsersCat
    };

    const newUserSeries: Highcharts.SeriesOptionsType[] = [{
      name: 'Number of App User Registration',
      type: 'column',
      data: newUsersData,
      color: "rgba(1, 183, 230, 0.4)",
      borderColor: "rgba(1, 183, 230, 0.4)",
      borderWidth: 2
    }];

    this.newAppUserRegisterChartOptions.xAxis = newUserXAxis;
    this.newAppUserRegisterChartOptions.series = newUserSeries;
    this.updateFlag = true;
    //#endregion
    
    //#region service request chart
    const newSerReqCat = this.dashboard.serviceRequestCharts.map(x => x.dateTimeText) as [];
    const newSerReqData = this.dashboard.serviceRequestCharts.map(x => x.totalServiceRequisition) as [];

    const newSerReqXAxis: Highcharts.XAxisOptions = {
      categories: newSerReqCat
    };

    const newSerReqSeries: Highcharts.SeriesOptionsType[] = [{
      name: 'Number of Service Request',
      type: 'column',
      data: newSerReqData,
      color: "rgba(1, 183, 230, 0.4)",
      borderColor: "rgba(1, 183, 230, 0.4)",
      borderWidth: 2
    }];

    this.serviceRequestChartOptions.xAxis = newSerReqXAxis;
    this.serviceRequestChartOptions.series = newSerReqSeries;
    this.updateFlag = true;
    //#endregion
  }

  viewAppUserReports() {
		this.router.navigate(['/users/app-users']);
  }

}
