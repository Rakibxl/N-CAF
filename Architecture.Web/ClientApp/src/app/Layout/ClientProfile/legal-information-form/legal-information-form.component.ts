import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profLegalInfo } from '../../../Shared/Entity/ClientProfile/profLegalInfo';
import { LegalInfoService } from '../../../Shared/Services/ClientProfile/legal-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';

@Component({
    selector: 'app-legal-information-form',
    templateUrl: './legal-information-form.component.html',
    styleUrls: ['./legal-information-form.component.css']
})
export class LegalInformationFormComponent implements OnInit {
    public legalInfoForm = new profLegalInfo();

    constructor(private legalInfoService: LegalInfoService, private alertService: AlertService, private router: Router, private route: ActivatedRoute) { }
    private profileId: number;
    private legalInfoId: number;

    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.legalInfoId = +this.route.snapshot.paramMap.get("id") || 0;

        console.log("this.profileId:", this.profileId, "this.legalInfoId", this.legalInfoId);
        if (this.profileId != 0 && this.legalInfoId != 0) {
            this.getLegal()
        }
    }

    public onSubmit() {
        debugger;
        console.table(this.legalInfoForm);
        this.legalInfoForm.profileId = this.profileId;

        this.legalInfoService.saveLegalInfo(this.legalInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getLegal() {
        debugger;
        this.legalInfoService.getLegalById(this.profileId, this.legalInfoId).subscribe(
            (success: APIResponse) => {
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
