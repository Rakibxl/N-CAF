import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profOccupationInfo } from '../../../Shared/Entity/ClientProfile/profOccupationInfo';
import { OccupationInfoService } from '../../../Shared/Services/ClientProfile/occupation-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { DropdownService } from '../../../Shared/Services/Common/dropdown.service';


@Component({
    selector: 'app-occupation-information-form',
    templateUrl: './occupation-history-form.component.html',
    styleUrls: ['./occupation-history-form.component.css']
})
export class OccupationHistoryFormComponent implements OnInit {
    public occupationInfoForm = new profOccupationInfo();
    public jobType = [];
    public contractType = [];

    constructor(private occupationInfoService: OccupationInfoService, private commonService: CommonService, private alertService: AlertService, private router: Router, private dropdownService: DropdownService, private route: ActivatedRoute) { }
    private profileId: number;
    private occupationInfoId: number;
    async ngOnInit() {

        this.jobType = await this.dropdownService.getJobType() || [];
        this.contractType = await this.dropdownService.getContractType() || [];

        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.occupationInfoId = +this.route.snapshot.paramMap.get("id") || 0;

        console.log("this.profileId:", this.profileId, "this.occupationInfoId", this.occupationInfoId);
        if (this.profileId != 0 && this.occupationInfoId != 0) {
            this.getOccupation()
        }
    }

    public onSubmit() {
       
        console.table(this.occupationInfoForm);
        this.occupationInfoForm.profileId = this.profileId;


        this.occupationInfoService.saveOccupationInfo(this.occupationInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/client-profile/occupation/${this.profileId}`]);
                }, 200);
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getOccupation() {
       
        this.occupationInfoService.getOccupationById(this.profileId, this.occupationInfoId).subscribe(
            (success: APIResponse) => {
                success.data.contractStartDate = this.commonService.getDateToSetForm(success.data.contractStartDate);
                success.data.contractEndDate = this.commonService.getDateToSetForm(success.data.contractEndDate);
                this.occupationInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate([`/client-profile/occupation/${this.profileId}`]);
        return false;
    }

}
