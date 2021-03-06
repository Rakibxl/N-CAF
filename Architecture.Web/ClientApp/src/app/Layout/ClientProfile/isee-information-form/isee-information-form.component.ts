import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profISEEInfo } from '../../../Shared/Entity/ClientProfile/profISEEInfo';
import { ISEEInfoService } from '../../../Shared/Services/ClientProfile/isee-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { DropdownService } from '../../../Shared/Services/Common/dropdown.service';

@Component({
  selector: 'app-isee-information-form',
  templateUrl: './isee-information-form.component.html',
  styleUrls: ['./isee-information-form.component.css']
})
export class IseeInformationFormComponent implements OnInit {
    public iseeInfoForm = new profISEEInfo();

    constructor(private iseeInfoService: ISEEInfoService, private alertService: AlertService, private commonService: CommonService, private router: Router, private route: ActivatedRoute, private dropdownService: DropdownService) { }
    private profileId: number;
    private iseeInfoId: number;
    public iseeClassTypeDropdown: any[] = [];
    async ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.iseeInfoId = +this.route.snapshot.paramMap.get("id") || 0;
        this.iseeClassTypeDropdown = await this.dropdownService.getISEEClassType() || [];

        console.log("this.profileId:", this.profileId, "this.iseeInfoId", this.iseeInfoId);
        if (this.profileId != 0 && this.iseeInfoId != 0) {
            this.getIsee()
        }
    }

    public onSubmit() {
        console.table(this.iseeInfoForm);
        this.iseeInfoForm.profileId = this.profileId;


        this.iseeInfoService.saveISEEInfo(this.iseeInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/client-profile/isee-info/${this.profileId}`]);
                }, 200);

            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getIsee() {
       
        this.iseeInfoService.getIseeById(this.profileId, this.iseeInfoId).subscribe(
            (success: APIResponse) => {
                success.data.submittedDate = this.commonService.getDateToSetForm(success.data.submittedDate);
                success.data.deliveryDate = this.commonService.getDateToSetForm(success.data.deliveryDate);
                success.data.expiryDate = this.commonService.getDateToSetForm(success.data.expiryDate);
                this.iseeInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate([`/client-profile/isee-info/${this.profileId}`]);
        return false;
    }

}
