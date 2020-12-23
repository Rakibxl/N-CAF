import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ProfFamilyInfo } from '../../../Shared/Entity/ClientProfile/profFamilyInfo';
import { FamilyInfoService } from '../../../Shared/Services/ClientProfile/family-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-family-information-form',
  templateUrl: './family-information-form.component.html',
  styleUrls: ['./family-information-form.component.css']
})
export class FamilyInformationFormComponent implements OnInit {
    public familyInfoForm = new ProfFamilyInfo();
    constructor(private familyInfoService: FamilyInfoService, private alertService: AlertService, private commonService: CommonService, private router: Router, private route: ActivatedRoute,) { }
    private profileId: number;
    private familyInfoId: number;
    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.familyInfoId = +this.route.snapshot.paramMap.get("id") || 0;

        console.log("this.profileId:", this.profileId, "this.familyInfoId", this.familyInfoId);
        if (this.profileId != 0 && this.familyInfoId != 0) {
            this.getFamily()
        }
    }


    public onSubmit() {
        console.table(this.familyInfoForm);
        this.familyInfoForm.profileId = this.profileId;

        this.familyInfoService.saveFamilyInfo(this.familyInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/client-profile/family-info/${this.profileId}`]);
                }, 200);
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getFamily() {
        debugger;
        this.familyInfoService.getFamilyById(this.profileId, this.familyInfoId).subscribe(
            (success: APIResponse) => {

                success.data.dateOfBirth = this.commonService.getDateToSetForm(success.data.dateOfBirth); 
                success.data.applicationDate = this.commonService.getDateToSetForm(success.data.applicationDate); 
                success.data.applicationPlacedDate = this.commonService.getDateToSetForm(success.data.applicationPlacedDate); 

                this.familyInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate([`/client-profile/family-info/${this.profileId}`]);
        return false;
    }


}
