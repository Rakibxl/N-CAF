import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { profOccupationInfo } from '../../../Shared/Entity/ClientProfile/profOccupationInfo';
import { OccupationInfoService } from '../../../Shared/Services/ClientProfile/occupation-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';


@Component({
    selector: 'app-occupation-information-form',
    templateUrl: './occupation-history-form.component.html',
    styleUrls: ['./occupation-history-form.component.css']
})
export class OccupationHistoryFormComponent implements OnInit {
    public occupationInfoForm = new profOccupationInfo();

    constructor(private occupationInfoService: OccupationInfoService, private alertService: AlertService, private router: Router) { }

    ngOnInit() {
    }

    public onSubmit() {
        debugger;
        console.table(this.occupationInfoForm);
        this.occupationInfoForm.profileId = 2;


        this.occupationInfoService.saveOccupationInfo(this.occupationInfoForm).subscribe(
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
        this.router.navigate(['/client-profile/occupation']);
    }
}
