import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profWorkerInfo } from '../../../Shared/Entity/ClientProfile/profWorkerInfo';
import { WorkerInfoService } from '../../../Shared/Services/ClientProfile/worker-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { DropdownService } from '../../../Shared/Services/Common/dropdown.service';

@Component({
    selector: 'app-worker-information-form',
    templateUrl: './worker-information-form.component.html',
    styleUrls: ['./worker-information-form.component.css']
})
export class WorkerInformationFormComponent implements OnInit {
    public workerInfoForm = new profWorkerInfo();

    constructor(private workerInfoService: WorkerInfoService, private alertService: AlertService, private commonService: CommonService, private router: Router, private route: ActivatedRoute, private dropdownService: DropdownService) { }
    private profileId: number;
    private workerInfoId: number;
    public workerTypeDropdown: any[] = [];
    async ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.workerInfoId = +this.route.snapshot.paramMap.get("id") || 0;
        this.workerTypeDropdown = await this.dropdownService.getWorkerType() || [];

        console.log("this.profileId:", this.profileId, "this.workerInfoId", this.workerInfoId, "this.workerTypeDropdown::", this.workerTypeDropdown);
        if (this.profileId != 0 && this.workerInfoId != 0) {
            this.getWorker()
        }
    }

    public onSubmit() {
        console.table(this.workerInfoForm);
        this.workerInfoForm.profileId = this.profileId;

        this.workerInfoService.saveWorkerInfo(this.workerInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/client-profile/worker-info/${this.profileId}`]);
                }, 200);

            },
            (error: any) => {
                //this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getWorker() {
        debugger;
        this.workerInfoService.getWorkerById(this.profileId, this.workerInfoId).subscribe(
            (success: APIResponse) => {
                success.data.startDate = this.commonService.getDateToSetForm(success.data.startDate);
                success.data.endDate = this.commonService.getDateToSetForm(success.data.endDate);

                this.workerInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate([`/client-profile/worker-info/${this.profileId}`]);
        return false;
    }
}
