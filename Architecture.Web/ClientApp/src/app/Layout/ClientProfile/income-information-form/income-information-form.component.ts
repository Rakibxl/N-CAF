import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { profIncomeInfo } from '../../../Shared/Entity/ClientProfile/profIncomeInfo';
import { IncomeInfoService } from '../../../Shared/Services/ClientProfile/income-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';

@Component({
  selector: 'app-income-information-form',
  templateUrl: './income-information-form.component.html',
  styleUrls: ['./income-information-form.component.css']
})
export class IncomeInformationFormComponent implements OnInit {
    public incomeInfoForm = new profIncomeInfo();

    constructor(private incomeInfoService: IncomeInfoService, private alertService: AlertService, private router: Router) { }


  ngOnInit() {
  }
    public onSubmit() {
        debugger;
        console.table(this.incomeInfoForm);
        this.incomeInfoForm.profileId = 2;

        this.incomeInfoService.saveIncomeInfo(this.incomeInfoForm).subscribe(
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
        this.router.navigate(['/client-profile/income-info']);
    }
}
