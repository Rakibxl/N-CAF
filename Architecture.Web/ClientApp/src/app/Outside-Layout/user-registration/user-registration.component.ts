
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { AlertService } from '../../Shared/Modules/alert/alert.service';
import { AuthService } from '../../Shared/Services/Users/auth.service';
import { CommonService } from '../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
})
export class UserRegistrationComponent implements OnInit {
  @Output() OnClickChange = new EventEmitter() || null;
  userRegistrationForm: FormGroup;

  constructor(private fb: FormBuilder, private commonService: CommonService, private router: Router, private alertService: AlertService, private authService: AuthService) {
    this.initForm();
  }

    public otpEnable: boolean = false;
    public myOptions: any = [];
    public errorMessage: string;
    public validationPhoneNumber: string;

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
        this.errorMessage = null;
    this.OnClickChange.emit("loginForm");
  }

    public fnLogin() {
        this.errorMessage = null;
    this.router.navigate(["/dashboard/common"]);
  }

  register() {
      this.errorMessage = null;
      let formData = this.userRegistrationForm.value;
      this.validationPhoneNumber = formData.phoneNumber;
    if (formData.password != formData.confirm_password) {
        this.errorMessage=('Password not matched!');
      return;
    }
    if (formData.password.length < 6) {
        this.errorMessage=('Password must more than 6 character!');
      return;
    }
    formData.genderId = formData.genderId ? parseInt(formData.genderId) : null;

    this.alertService.fnLoading(true);
    this.commonService.startLoading();
    this.authService.register(formData).subscribe((res: any) => {
      this.commonService.stopLoading();
      this.alertService.fnLoading(false);
      if (res && res.message) {
        this.userRegistrationForm.reset();
        }
        this.otpEnable = !this.otpEnable;
    }, err => {
      this.commonService.stopLoading();
      this.alertService.fnLoading(false);
      if (err.status == 400) {
          this.errorMessage= "Validation failed for " + err.error.errors[0].propertyName + ". "
          + err.error.errors[0].errorList[0];
          this.alertService.tosterDanger(this.errorMessage);
      }
    });
    }

    public maskingPhoneNumber(): string {
        if (this.validationPhoneNumber.length > 4) {
            let markingNumber = this.validationPhoneNumber.substr(0, this.validationPhoneNumber.length - 3).replace(/[0-9]/g, "X");;
            var restNumber = this.validationPhoneNumber.substr(this.validationPhoneNumber.length - 3, 3);
            return markingNumber + restNumber;
        }
        
        return this.validationPhoneNumber;
    }
}
