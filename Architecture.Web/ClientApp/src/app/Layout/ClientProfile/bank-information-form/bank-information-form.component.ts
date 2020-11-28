import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { profBankInfo } from '../../../Shared/Entity/ClientProfile/profBankInfo';
import { BankInfoService } from '../../../Shared/Services/ClientProfile/bank-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';


@Component({
    selector: 'app-bank-information-form',
    templateUrl: './bank-information-form.component.html',
    styleUrls: ['./bank-information-form.component.css']
})
export class BankInformationFormComponent implements OnInit {
    public bankInfoForm = new profBankInfo();

    constructor(private bankInfoService: BankInfoService, private alertService: AlertService, private router: Router) { }

    ngOnInit() {
    }

    public onSubmit() {
        debugger;
        console.table(this.bankInfoForm);
        this.bankInfoForm.profileId = 2;


        this.bankInfoService.saveBankInfo(this.bankInfoForm).subscribe(
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
        this.router.navigate(['/client-profile/bank-info']);
    }
}
