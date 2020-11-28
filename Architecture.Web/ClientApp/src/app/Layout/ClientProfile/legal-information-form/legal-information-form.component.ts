import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { profLegalInfo } from '../../../Shared/Entity/ClientProfile/profLegalInfo';
import { LegalInfoService } from '../../../Shared/Services/ClientProfile/legal-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';


@Component({
    selector: 'app-legal-information-form',
    templateUrl: './legal-information-form.component.html',
    styleUrls: ['./legal-information-form.component.css']
})
export class LegalInformationFormComponent implements OnInit {
    public legalInfoForm = new profLegalInfo();

    constructor(private legalInfoService: LegalInfoService, private alertService: AlertService, private router: Router) { }

    ngOnInit() {
    }

    public onSubmit() {
        debugger;
        console.table(this.legalInfoForm);
        this.legalInfoForm.profileId = 2;


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

    public fnBackToList() {
        this.router.navigate(['/client-profile/legal-info']);
    }
}
