import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profInsuranceInfo } from '../../../Shared/Entity/ClientProfile/profInsuranceInfo';
import { InsuranceInfoService } from '../../../Shared/Services/ClientProfile/insurance-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
    selector: 'app-insurance-information-form',
    templateUrl: './insurance-information-form.component.html',
    styleUrls: ['./insurance-information-form.component.css']
})
export class InsuranceInformationFormComponent implements OnInit {
    public insuranceInfoForm = new profInsuranceInfo();

    constructor(private insuranceInfoService: InsuranceInfoService, private alertService: AlertService, private commonService: CommonService, private router: Router, private route: ActivatedRoute) { }
    private profileId: number;
    private insuranceInfoId: number;
    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.insuranceInfoId = +this.route.snapshot.paramMap.get("id") || 0;

        console.log("this.profileId:", this.profileId, "this.insuranceInfoId", this.insuranceInfoId);
        if (this.profileId != 0 && this.insuranceInfoId != 0) {
            this.getInsurance()
        }
    }

    public onSubmit() {
        debugger;
        console.table(this.insuranceInfoForm);
        this.insuranceInfoForm.profileId = this.profileId;

        this.insuranceInfoService.saveInsuranceInfo(this.insuranceInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getInsurance() {
        debugger;
        this.insuranceInfoService.getInsuranceById(this.profileId, this.insuranceInfoId).subscribe(
            (success: APIResponse) => {
                success.data.startDate = this.commonService.getDateToSetForm(success.data.startDate);
                success.data.endDate = this.commonService.getDateToSetForm(success.data.endDate);
                this.insuranceInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate([`/client-profile/insurance-info/${this.profileId}`]);
        return false;
    }
}
