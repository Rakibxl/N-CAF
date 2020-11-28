import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { profAssetInfo } from '../../../Shared/Entity/ClientProfile/profAssetInfo';
import { AssetInfoService } from '../../../Shared/Services/ClientProfile/asset-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';


@Component({
  selector: 'app-asset-information-form',
  templateUrl: './asset-information-form.component.html',
  styleUrls: ['./asset-information-form.component.css']
})
export class AssetInformationFormComponent implements OnInit {
    public assetInfoForm = new profAssetInfo();

    constructor(private assetInfoService: AssetInfoService, private alertService: AlertService, private router: Router) { }

  ngOnInit() {
   }

    public onSubmit() {
        debugger;
        console.table(this.assetInfoForm);
        this.assetInfoForm.profileId = 2;


        this.assetInfoService.saveAssetInfo(this.assetInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate(['/client-profile/asset-info']);
    }

}
