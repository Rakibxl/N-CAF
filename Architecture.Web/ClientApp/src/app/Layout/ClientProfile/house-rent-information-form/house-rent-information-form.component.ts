import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profHouseRentInfo } from '../../../Shared/Entity/ClientProfile/profHouseRentInfo';
import { HouseRentInfoService } from '../../../Shared/Services/ClientProfile/houserent-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';


@Component({
  selector: 'app-house-rent-information-form',
  templateUrl: './house-rent-information-form.component.html',
  styleUrls: ['./house-rent-information-form.component.css']
})
export class HouseRentInformationFormComponent implements OnInit {
    public houseRentInfoForm = new profHouseRentInfo();

    constructor(private houseRentInfoService: HouseRentInfoService, private alertService: AlertService, private router: Router, private route: ActivatedRoute) { }
    private profileId: number;
    private houseRentInfoId: number;

    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.houseRentInfoId = +this.route.snapshot.paramMap.get("id") || 0;

        console.log("this.profileId:", this.profileId, "this.houserentInfoId", this.houseRentInfoId);
        if (this.profileId != 0 && this.houseRentInfoId != 0) {
            this.getHouseRent()
        }
    }

    public onSubmit() {
        debugger;
        console.table(this.houseRentInfoForm);
        this.houseRentInfoForm.profileId = this.profileId;


        this.houseRentInfoService.saveHouseRentInfo(this.houseRentInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getHouseRent() {
        debugger;
        this.houseRentInfoService.getHouseRentById(this.profileId, this.houseRentInfoId).subscribe(
            (success: APIResponse) => {
                this.houseRentInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate([`/client-profile/house-rent/${this.profileId}`]);
        return false;
    }

}
