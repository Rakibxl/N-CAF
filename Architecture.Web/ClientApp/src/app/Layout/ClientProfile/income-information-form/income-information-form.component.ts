import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profIncomeInfo } from '../../../Shared/Entity/ClientProfile/profIncomeInfo';
import { IncomeInfoService } from '../../../Shared/Services/ClientProfile/income-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-income-information-form',
  templateUrl: './income-information-form.component.html',
  styleUrls: ['./income-information-form.component.css']
})
export class IncomeInformationFormComponent implements OnInit {
    public incomeInfoForm = new profIncomeInfo();

    constructor(private incomeInfoService: IncomeInfoService, private alertService: AlertService, private commonService: CommonService, private router: Router, private route: ActivatedRoute) { }
    private profileId: number;
    private incomeInfoId: number;

    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.incomeInfoId = +this.route.snapshot.paramMap.get("id") || 0;

        console.log("this.profileId:", this.profileId, "this.incomeInfoId", this.incomeInfoId);
        if (this.profileId != 0 && this.incomeInfoId != 0) {
            this.getIncome()
        }
  }
    public onSubmit() {
        debugger;
        console.table(this.incomeInfoForm);
        this.incomeInfoForm.profileId = this.profileId;

        this.incomeInfoService.saveIncomeInfo(this.incomeInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/client-profile/income-info/${this.profileId}`]);
                }, 200);
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    
    public getIncome() {
        debugger;
        this.incomeInfoService.getIncomeById(this.profileId, this.incomeInfoId).subscribe(
            (success: APIResponse) => {

                success.data.year = this.commonService.getDateToSetForm(success.data.year);
                success.data.month = this.commonService.getDateToSetForm(success.data.month);
                this.incomeInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate([`/client-profile/income-info/${this.profileId}`]);
        return false;
    }
}
