import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { profMovementInfo } from '../../../Shared/Entity/ClientProfile/profMovementInfo';
import { MovementInfoService } from '../../../Shared/Services/ClientProfile/movement-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';


@Component({
  selector: 'app-movement-information-form',
  templateUrl: './movement-information-form.component.html',
  styleUrls: ['./movement-information-form.component.css']
})
export class MovementInformationFormComponent implements OnInit {

    public movementInfoForm = new profMovementInfo();

    constructor(private movementInfoService: MovementInfoService, private alertService: AlertService, private router: Router) { }

    ngOnInit() {
    }

    public onSubmit() {
        debugger;
        console.table(this.movementInfoForm);
        this.movementInfoForm.profileId = 2;


        this.movementInfoService.saveMovementInfo(this.movementInfoForm).subscribe(
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
        this.router.navigate(['/client-profile/movement-info']);
    }

}
