import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profHouseRentInfo } from '../../../Shared/Entity/ClientProfile/profHouseRentInfo';
import { HouseRentInfoService } from '../../../Shared/Services/ClientProfile/houserent-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { DropdownService } from '../../../Shared/Services/Common/dropdown.service';

@Component({
  selector: 'app-house-rent-information-form',
  templateUrl: './house-rent-information-form.component.html',
  styleUrls: ['./house-rent-information-form.component.css']
})
export class HouseRentInformationFormComponent implements OnInit {
    public houseRentInfoForm = new profHouseRentInfo();

    constructor(private houseRentInfoService: HouseRentInfoService, private alertService: AlertService, private commonService: CommonService, private router: Router, private route: ActivatedRoute, private dropdownService: DropdownService) { }
    private profileId: number;
    private houseRentInfoId: number;
    public HouseTypeDropdown: any[] = [];
    public contractTypeDropdown: any[] = [];
    public houseCategoryDropdown: any[] = [];
    public loanInterestTypeDropdown: any[] = [];
    public loanStatusTypeDropdown: any[] = [];

    async ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.houseRentInfoId = +this.route.snapshot.paramMap.get("id") || 0;

        this.HouseTypeDropdown = await this.dropdownService.getHouseType() || [];
        this.contractTypeDropdown = await this.dropdownService.getContractType() || [];
        this.loanInterestTypeDropdown = await this.dropdownService.getLoanInterestType() || [];
        this.houseCategoryDropdown = await this.dropdownService.getHouseCategory() || [];
        this.loanStatusTypeDropdown = await this.dropdownService.getLoanStatusType() || [];

        console.log("this.profileId:", this.profileId, "this.houserentInfoId", this.houseRentInfoId);
        if (this.profileId != 0 && this.houseRentInfoId != 0) {
            this.getHouseRent()
        }
    }

    public onSubmit() {
       
        console.table(this.houseRentInfoForm);
        this.houseRentInfoForm.profileId = this.profileId;


        this.houseRentInfoService.saveHouseRentInfo(this.houseRentInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/client-profile/house-rent/${this.profileId}`]);
                }, 200);
            },
            (error: any) => {
                //this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getHouseRent() {
       
        this.houseRentInfoService.getHouseRentById(this.profileId, this.houseRentInfoId).subscribe(
            (success: APIResponse) => {

                success.data.contractDate = this.commonService.getDateToSetForm(success.data.contractDate);
                success.data.startDate = this.commonService.getDateToSetForm(success.data.startDate);
                success.data.endDate = this.commonService.getDateToSetForm(success.data.endDate);
                success.data.loanStartDate = this.commonService.getDateToSetForm(success.data.loanStartDate);
                success.data.registrationDate = this.commonService.getDateToSetForm(success.data.registrationDate);
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
