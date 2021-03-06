import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profMovementInfo } from '../../../Shared/Entity/ClientProfile/profMovementInfo';
import { MovementInfoService } from '../../../Shared/Services/ClientProfile/movement-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { DropdownService } from '../../../Shared/Services/Common/dropdown.service';

@Component({
  selector: 'app-movement-information-form',
  templateUrl: './movement-information-form.component.html',
  styleUrls: ['./movement-information-form.component.css']
})
export class MovementInformationFormComponent implements OnInit {

    public movementInfoForm = new profMovementInfo();

    constructor(private movementInfoService: MovementInfoService, private alertService: AlertService, private commonService: CommonService, private router: Router, private route: ActivatedRoute, private dropdownService: DropdownService) { }
    private profileId: number;
    private movementInfoId: number;
    public countryNameDropdown: any[] = [];

    async ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.movementInfoId = +this.route.snapshot.paramMap.get("id") || 0;

        this.countryNameDropdown = await this.dropdownService.getCountryName() || [];

        console.log("this.profileId:", this.profileId, "this.movementInfoId", this.movementInfoId);
        if (this.profileId != 0 && this.movementInfoId != 0) {
            this.getMovement()
        }
    }

    public onSubmit() {
       
        console.table(this.movementInfoForm);
        this.movementInfoForm.profileId = this.profileId;


        this.movementInfoService.saveMovementInfo(this.movementInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/client-profile/movement-info/${this.profileId}`]);
                }, 200);
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getMovement() {
       
        this.movementInfoService.getMovementById(this.profileId, this.movementInfoId).subscribe(
            (success: APIResponse) => {
                success.data.startDate = this.commonService.getDateToSetForm(success.data.startDate);
                success.data.endDate = this.commonService.getDateToSetForm(success.data.endDate);
                this.movementInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate([`/client-profile/movement-info/${this.profileId}`]);
        return false;
    }

}
