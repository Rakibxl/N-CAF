
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { AlertService } from '../../Shared/Modules/alert/alert.service';
import { AuthService } from '../../Shared/Services/Users/auth.service';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
})
export class UserRegistrationComponent implements OnInit {
  @Output() OnClickChange = new EventEmitter() || null;
  userRegistrationForm: FormGroup;

  constructor(private fb: FormBuilder, private router: Router, private alertService: AlertService, private authService: AuthService) {
    this.initForm();
  }

  otpEnable: boolean = false;
  myOptions: any = [];

  ngOnInit() {

  }

  initForm() {
    this.userRegistrationForm = this.fb.group({
      name: [null, Validators.required],
      surName: [null],
      // userId: [null],
      email: [null, Validators.required],
      phoneNumber: [null, Validators.required],
      password: [null, Validators.required],
      confirm_password: [null, Validators.required],
      genderId: [null, Validators.required]
    });
  }

  // public toggleOptEnable = () => this.otpEnable = !this.otpEnable;

  public showingLoginForm() {
    this.OnClickChange.emit("loginForm");
  }

  public fnLogin() {
    this.router.navigate(["/dashboard/common"]);
  }

  register() {
    this.otpEnable = !this.otpEnable;

    let formData = this.userRegistrationForm.value;
    if (formData.password != formData.confirm_password) {
      alert('Password not matched!');
      return;
    }
    formData.genderId = formData.genderId ? parseInt(formData.genderId) : null;

    this.alertService.fnLoading(true);
    this.authService.register(formData).subscribe(res => {
      this.alertService.fnLoading(false);
      //console.log(res)
    }, err => {
      this.alertService.fnLoading(false);
      if (err.status == 400) {
        let errorMsg = "Validation failed for " + err.error.errors[0].propertyName + ". "
          + err.error.errors[0].errorList[0];
        this.alertService.tosterDanger(errorMsg);
      }
    });
  }
}
