import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { QuestionInfo } from '../../../Shared/Entity/Users/QuestionInfo';
import { QuestionInfoService } from '../../../Shared/Services/Users/question-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';

@Component({
  selector: 'app-question-information-form',
  templateUrl: './question-information-form.component.html',
  styleUrls: ['./question-information-form.component.css']
})
export class QuestionInformationFormComponent implements OnInit {
    public questionInfoForm = new QuestionInfo();

    constructor(private questionInfoService: QuestionInfoService, private alertService: AlertService, private router: Router, private route: ActivatedRoute) { }
    private profileId: number;
    private questionInfoId: number;
    ngOnInit() {
        this.questionInfoId = +this.route.snapshot.paramMap.get("id") || 0;
        if (this.questionInfoId != 0) {
            this.getQuestion()        
        }
        
    }


    public onSubmit() {
        debugger;
        console.table(this.questionInfoForm);

        this.questionInfoService.saveQuestionInfo(this.questionInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/manager/question-info`]);
                }, 200);
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getQuestion() {
        debugger;
        this.questionInfoService.getQuestionById(this.questionInfoId).subscribe(
            (success: APIResponse) => {
                this.questionInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate([`/manager/question-info`]);
        return false;
    }



}
