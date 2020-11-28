import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { profWorkerInfo } from '../../../Shared/Entity/ClientProfile/profWorkerInfo';
import { WorkerInfoService } from '../../../Shared/Services/ClientProfile/worker-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';


@Component({
    selector: 'app-worker-information-form',
    templateUrl: './worker-information-form.component.html',
    styleUrls: ['./worker-information-form.component.css']
})
export class WorkerInformationFormComponent implements OnInit {
    public workerInfoForm = new profWorkerInfo();

    constructor(private workerInfoService: WorkerInfoService, private alertService: AlertService, private router: Router) { }

    ngOnInit() {
    }

    public onSubmit() {
        debugger;
        console.table(this.workerInfoForm);
        this.workerInfoForm.profileId = 2;


        this.workerInfoService.saveWorkerInfo(this.workerInfoForm).subscribe(
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
        this.router.navigate(['/client-profile/worker-info']);
    }
}
