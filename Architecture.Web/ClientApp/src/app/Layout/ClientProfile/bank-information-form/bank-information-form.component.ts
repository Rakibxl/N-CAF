import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profBankInfo } from '../../../Shared/Entity/ClientProfile/profBankInfo';
import { BankInfoService } from '../../../Shared/Services/ClientProfile/bank-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { DropdownService } from '../../../Shared/Services/Common/dropdown.service';


@Component({
    selector: 'app-bank-information-form',
    templateUrl: './bank-information-form.component.html',
    styleUrls: ['./bank-information-form.component.css']
})
export class BankInformationFormComponent implements OnInit {
    public bankInfoForm = new profBankInfo();

    constructor(private bankInfoService: BankInfoService, private alertService: AlertService, private router: Router, private route: ActivatedRoute, private dropdownService: DropdownService) { }
    private profileId: number;
    private bankInfoId: number;
    public bankNameDropdown: any[] = [];
    async ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.bankInfoId = +this.route.snapshot.paramMap.get("id") || 0;
        this.bankNameDropdown = await this.dropdownService.getBankName() || [];

        console.log("this.profileId:", this.profileId, "this.bankInfoId", this.bankInfoId);
        if (this.profileId != 0 && this.bankInfoId != 0) {
            this.getBank()
        }
    }

    public onSubmit() {
       
        console.table(this.bankInfoForm);
        this.bankInfoForm.profileId = this.profileId;

        this.bankInfoService.saveBankInfo(this.bankInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/client-profile/bank-info/${this.profileId}`]);
                }, 200);

            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getBank() {
       
        this.bankInfoService.getBankById(this.profileId, this.bankInfoId).subscribe(
            (success: APIResponse) => {
                this.bankInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate([`/client-profile/bank-info/${this.profileId}`]);
        return false;
    }

 
}
