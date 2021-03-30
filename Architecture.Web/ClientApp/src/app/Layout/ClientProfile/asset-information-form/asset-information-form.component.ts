import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profAssetInfo } from '../../../Shared/Entity/ClientProfile/profAssetInfo';
import { AssetInfoService } from '../../../Shared/Services/ClientProfile/asset-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-asset-information-form',
  templateUrl: './asset-information-form.component.html',
  styleUrls: ['./asset-information-form.component.css']
})
export class AssetInformationFormComponent implements OnInit {
    public assetInfoForm = new profAssetInfo();

    constructor(private assetInfoService: AssetInfoService, private alertService: AlertService, private commonService: CommonService, private router: Router, private route: ActivatedRoute) { }
    private profileId: number = null;
    private assetInfoId: number = null;

    public ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.assetInfoId = +this.route.snapshot.paramMap.get("id") || 0;

        console.log("this.profileId:", this.profileId, "this.assetInfoId", this.assetInfoId);
        if (this.profileId != 0 && this.assetInfoId != 0) {
            this.getAsset()
        }
   }

    public onSubmit() {
        console.table(this.assetInfoForm);
        this.assetInfoForm.profileId = this.profileId;

        this.assetInfoService.saveAssetInfo(this.assetInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/client-profile/asset-info/${this.profileId}`]);
                }, 200);

            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });
    }

    public getAsset() {
        this.assetInfoService.getAssetById(this.profileId, this.assetInfoId).subscribe(
            (success: APIResponse) => {
                success.data.ownerFromDate = this.commonService.getDateToSetForm(success.data.ownerFromDate);
                this.assetInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });
    }

    public fnBackToList() {
        this.router.navigate([`/client-profile/asset-info/${this.profileId}`]);
        return false;
    }
}
