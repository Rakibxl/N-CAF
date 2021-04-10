import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profLegalInfo } from '../../../Shared/Entity/ClientProfile/profLegalInfo';
import { LegalInfoService } from '../../../Shared/Services/ClientProfile/legal-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { DropdownService } from '../../../Shared/Services/Common/dropdown.service';

@Component({
    selector: 'app-legal-information-form',
    templateUrl: './legal-information-form.component.html',
    styleUrls: ['./legal-information-form.component.css']
})
export class LegalInformationFormComponent implements OnInit {
    public legalInfoForm = new profLegalInfo();

    constructor(private legalInfoService: LegalInfoService, private alertService: AlertService, private commonService: CommonService, private router: Router, private route: ActivatedRoute, private dropdownService: DropdownService) { }
    private profileId: number;
    private legalInfoId: number;
    public countryNameDropdown: any[] = [];

    async ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.legalInfoId = +this.route.snapshot.paramMap.get("id") || 0;

        this.countryNameDropdown = await this.dropdownService.getCountryName() || [];

        console.log("this.profileId:", this.profileId, "this.legalInfoId", this.legalInfoId);
        if (this.profileId != 0 && this.legalInfoId != 0) {
            this.getLegal()
        }
    }

    public onSubmit() {
       
        console.table(this.legalInfoForm);
        this.legalInfoForm.profileId = this.profileId;

        this.legalInfoService.saveLegalInfo(this.legalInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/client-profile/legal-info/${this.profileId}`]);
                }, 200);
            },
            (error: any) => {
                //this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getLegal() {
       
        this.legalInfoService.getLegalById(this.profileId, this.legalInfoId).subscribe(
            (success: APIResponse) => {
                success.data.startDate = this.commonService.getDateToSetForm(success.data.startDate);
                success.data.endDate = this.commonService.getDateToSetForm(success.data.endDate);
                this.legalInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate([`/client-profile/legal-info/${this.profileId}`]);
        return false;
    }
}
