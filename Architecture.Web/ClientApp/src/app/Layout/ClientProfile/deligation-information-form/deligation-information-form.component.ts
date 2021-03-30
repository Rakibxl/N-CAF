import { Component, OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';
import { profDelegationInfo } from '../../../Shared/Entity/ClientProfile/profDelegationInfo';
import { DelegationInfoService } from '../../../Shared/Services/ClientProfile/delegation-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-deligation-information-form',
  templateUrl: './deligation-information-form.component.html',
  styleUrls: ['./deligation-information-form.component.css']
})
export class DeligationInformationFormComponent implements OnInit {

    public delegationInfoForm = new profDelegationInfo();

    constructor(private delegationInfoService: DelegationInfoService, private alertService: AlertService, private commonService: CommonService, private router: Router, private route: ActivatedRoute) { }
    private profileId: number;
    private delegationInfoId: number;
    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.delegationInfoId = +this.route.snapshot.paramMap.get("id") || 0;

        console.log("this.profileId:", this.profileId, "this.delegationInfoId", this.delegationInfoId);
        if (this.profileId != 0 && this.delegationInfoId != 0) {
            this.getEducation()
        }
    }

    public onSubmit() {
        console.table(this.delegationInfoForm);
        this.delegationInfoForm.profileId = this.profileId;


        this.delegationInfoService.saveDelegationInfo(this.delegationInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/client-profile/deligation-info/${this.profileId}`]);
                }, 200);

            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getEducation() {
        this.delegationInfoService.getDelegationById(this.profileId, this.delegationInfoId).subscribe(
            (success: APIResponse) => {
                success.data.dateOfBirth = this.commonService.getDateToSetForm(success.data.dateOfBirth);
                success.data.documentIssueDate = this.commonService.getDateToSetForm(success.data.documentIssueDate);
                success.data.expiryDate = this.commonService.getDateToSetForm(success.data.expiryDate);
                this.delegationInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate([`/client-profile/deligation-info/${this.profileId}`]);
        return false;
    }

}
