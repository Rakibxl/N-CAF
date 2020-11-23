import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { profHouseRentInfo } from '../../../Shared/Entity/ClientProfile/profHouseRentInfo';
import { HouseRentInfoService } from '../../../Shared/Services/ClientProfile/houserent-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';

@Component({
  selector: 'app-house-rent-information-form',
  templateUrl: './house-rent-information-form.component.html',
  styleUrls: ['./house-rent-information-form.component.css']
})
export class HouseRentInformationFormComponent implements OnInit {
    public houseRentInfoForm = new profHouseRentInfo();

    constructor(private houseRentInfoService: HouseRentInfoService, private alertService: AlertService, private router: Router) { }

  ngOnInit() {
    }

    public onSubmit() {
        debugger;
        console.table(this.houseRentInfoForm);
        this.houseRentInfoForm.profileId = 2;


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

    public fnBackToList() {
        this.router.navigate(['/client-profile/houseRent']);
    }

}
