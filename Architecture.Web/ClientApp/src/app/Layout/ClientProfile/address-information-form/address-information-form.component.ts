import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { profAddressInfo } from '../../../Shared/Entity/ClientProfile/profAddressInfo';
import { AddressInfoService } from '../../../Shared/Services/ClientProfile/address-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';


@Component({
    selector: 'app-address-information-form',
    templateUrl: './address-information-form.component.html',
    styleUrls: ['./address-information-form.component.css']
})
export class AddressInformationFormComponent implements OnInit {
    public addressInfoForm = new profAddressInfo();

    constructor(private addressInfoService: AddressInfoService, private alertService: AlertService, private router: Router) { }

    ngOnInit() {
    }

    public onSubmit() {
        debugger;
        console.table(this.addressInfoForm);
        this.addressInfoForm.profileId = 2;


        this.addressInfoService.saveAddressInfo(this.addressInfoForm).subscribe(
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
        this.router.navigate(['/client-profile/address']);
    }
}
