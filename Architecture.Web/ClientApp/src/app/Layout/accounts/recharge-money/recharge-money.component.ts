import { Component, OnInit } from '@angular/core';
import { TransactionRequest } from "../../../Shared/Entity/Accounts/transactionRequest";
import { AlertService } from "../../../Shared/Modules/alert/alert.service";
import { DropdownService } from "../../../Shared/Services/Common/dropdown.service";
import { Router, ActivatedRoute } from '@angular/router';
import { RechargeService } from '../../../Shared/Services/Accounts/recharge.service';

@Component({
    selector: 'app-recharge-money',
    templateUrl: './recharge-money.component.html',
    styleUrls: ['./recharge-money.component.css']
})


export class RechargeMoneyComponent implements OnInit {

    public transactionRequest = new TransactionRequest();
    public paymentTypeDropdown: any[] = [];
    public refreshComponent: boolean = true;

    constructor(private rechargeService: RechargeService, private alertService: AlertService, private router: Router, private route: ActivatedRoute, private dropdownService: DropdownService) { }


    async ngOnInit() {
        this.paymentTypeDropdown = await this.dropdownService.getPaymentType() || [];
    }

    public onSubmit() {

        this.rechargeService.saveRechargeMoney(this.transactionRequest).subscribe(
            (success: any) => {
                this.refreshComponent = false;
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.refreshComponent = true;
                }, 7000);
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }
}
