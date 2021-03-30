import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profAddressInfo } from '../../../Shared/Entity/ClientProfile/profAddressInfo';
import { AddressInfoService } from '../../../Shared/Services/ClientProfile/address-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
    selector: 'app-address-information-form',
    templateUrl: './address-information-form.component.html',
    styleUrls: ['./address-information-form.component.css']
})
export class AddressInformationFormComponent implements OnInit {
    public addressInfoForm = new profAddressInfo();

    constructor(private addressInfoService: AddressInfoService, private alertService: AlertService, private commonService: CommonService, private router: Router, private route: ActivatedRoute) { }
    private profileId: number;
    private addressInfoId: number;

    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.addressInfoId = +this.route.snapshot.paramMap.get("id") || 0;

        console.log("this.profileId:", this.profileId, "this.addressInfoId", this.addressInfoId);
        if (this.profileId != 0 && this.addressInfoId != 0) {
            this.getAddress()
        }
    }

    public onSubmit() {
        console.table(this.addressInfoForm);
        this.addressInfoForm.profileId = this.profileId;

        this.addressInfoService.saveAddressInfo(this.addressInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/client-profile/address/${this.profileId}`]);
                }, 200);

            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getAddress() {
        this.addressInfoService.getAddressById(this.profileId, this.addressInfoId).subscribe(
            (success: APIResponse) => {
                success.data.startDate = this.commonService.getDateToSetForm(success.data.startDate);
                success.data.endDate = this.commonService.getDateToSetForm(success.data.endDate);
                this.addressInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate([`/client-profile/address/${this.profileId}`]);
        return false;
    }
 
}
