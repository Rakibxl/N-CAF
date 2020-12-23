import { Component, OnInit } from '@angular/core';
import { Color } from 'ng2-charts';
import { DashboardService } from 'src/app/Shared/Services/Dashboard/dashboard.service';
import { AlertService } from 'src/app/Shared/Modules/alert/alert.service';
import { QuestionInfoService } from '../../../Shared/Services/Users/question-info.service';
import { Router } from '@angular/router';
import { Dashboard } from 'src/app/Shared/Entity/Common/dashboard';
import * as Highcharts from 'highcharts';
import { timer } from 'rxjs';

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
      private questionService: QuestionInfoService,
    private router: Router
    ) { }

   public questiontimerSubscribe;


  ngOnInit() {     
      this.generateQuestion();
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


    generateQuestion() {

        var questionInfoList = [];
        // basic service , occupation and everything call

        this.questionService.GetUserQuestion().subscribe(
            (success) => {
                console.log("get question info: ", success);
                questionInfoList = success.data;

                // save in session storage array 
                if ((JSON.parse(sessionStorage.getItem('questioninfo')) || []).length==0) {
                    sessionStorage.setItem('questioninfo', JSON.stringify(success.data));
                }

                this.questiontimerSubscribe = timer(4000, 30000).subscribe(x => {
                    let questionInfos = JSON.parse(sessionStorage.getItem('questioninfo')) || [];
                    let displayQuestion = questionInfos.filter(x => x.status == "InActive").length > 0 ? questionInfos.filter(x => x.status == "InActive")[0] : null;
                    if (displayQuestion != null) {
                        questionInfos.forEach(r => { if (r.questionDescription == displayQuestion.questionDescription) r.status = "Active" });
                        console.log("questionInfos", questionInfos);
                        sessionStorage.setItem('questioninfo', JSON.stringify(questionInfos));
                        this.alertService.questionToster(displayQuestion.questionDescription,
                            () => {
                                console.log("Clicked Yes");
                                console.log("displayQuestion", displayQuestion.pageToUrl);
                                if ((displayQuestion.pageToUrl || "") != "") {
                                    window.open(`${displayQuestion.pageToUrl.replace("{profileId}", displayQuestion.sectionNameId)}`);
                                }
                            },
                            () => {
                                console.log("clicked No");
                            });

                    } else {
                        this.questiontimerSubscribe.unsubscribe();
                    }

                });



                 
                  //numbers.subscribe(x => console.log(x));


                //console.log("sessiondata" + data);



                //for (let i = 0; i < success.data.length; i++) {
                //    if (success.data[i].status == "InActive") {
                //        this.alertService.questionToster(success.data[i].questionDescription,
                //            () => {
                //                alert("Clicked Yes");
                //            },
                //            () => {
                //                alert("clicked No");
                //            });
                //        }
                //}
            },
            error => {
            });
       
    }


}
