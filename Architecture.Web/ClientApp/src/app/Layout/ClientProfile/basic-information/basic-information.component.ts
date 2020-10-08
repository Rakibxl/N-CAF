import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, Validators, FormBuilder, FormGroup } from '@angular/forms';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { DashboardService } from '../../../Shared/Services/Dashboard/dashboard.service';

@Component({
  selector: 'app-basic-information',
  templateUrl: './basic-information.component.html',
  styleUrls: ['./basic-information.component.css']
})
export class BasicInformationComponent implements OnInit {
  basicInfoForm: FormGroup;

  constructor(private fb: FormBuilder, private dashboardService: DashboardService, private alertService: AlertService, private router: Router) {
    this.initForm();
  }

  ngOnInit() {
    this.dashboardService.getDashboardData().subscribe(res => {

    });
  }

  initForm() {
    this.basicInfoForm = this.fb.group({
      name: [0],
      job_id: [''],
      org_id: ['', Validators.required]
    });
  }
}
