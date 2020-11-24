import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-application-user-form',
  templateUrl: './application-user-form.component.html',
  styleUrls: ['./application-user-form.component.css']
})
export class ApplicationUserFormComponent implements OnInit {
  appUserForm: FormGroup;

  constructor(private fb: FormBuilder, private router: Router) {
    this.initForm();
  }

  public backBtnClick() {
    this.router.navigate(["/manager/user-info"]);
  }

  ngOnInit() {
  }

  initForm() {
    this.appUserForm = this.fb.group({
      id: [null],
      name: [null, Validators.required],
      surName: [null, Validators.required],
      email: [null, Validators.required],
      phoneNumber: [null, Validators.required],
      password: [null, Validators.required],
      appUserTypeId: [null, Validators.required],
      branchId: [null, Validators.required],
      createdBy: [null],
      modifiedBy: [null]
    });
  }
}
