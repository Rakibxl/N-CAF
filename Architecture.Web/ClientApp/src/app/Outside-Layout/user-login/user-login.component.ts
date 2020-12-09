import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../Shared/Services/Users/auth.service';
import { AlertService } from '../../Shared/Modules/alert/alert.service';
import { CommonService } from '../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
})
export class UserLoginComponent implements OnInit {
  @Output() OnClickChange = new EventEmitter() || null;
  loginModel: any = {
    email: '',
    password: '',
    // branch: '',
  };

  constructor(private commonService: CommonService, private router: Router, private authService: AuthService, private alertService: AlertService) { }

  otpEnable: boolean = false;

  ngOnInit() {
  }

  toggleOptEnable = () => this.otpEnable = !this.otpEnable;

  public fnForgotPassword() {
    this.OnClickChange.emit("forgotPassword");
  }

  public fnRegistration() {
    this.OnClickChange.emit("registration");
  }

  public fnLogin() {
    // this.alertService.fnLoading(true);
    this.commonService.startLoading();
    this.authService.login(this.loginModel).subscribe(res => {
      console.log("successfully login...");
      console.log(res)
      this.router.navigate(["/dashboard/common"]);
      // this.alertService.fnLoading(false);
      this.commonService.stopLoading();
    }, err => {
      // this.alertService.fnLoading(false);
      this.commonService.stopLoading();
      if (err.status == 400) {
        let errorMsg = "Validation failed for " + err.error.errors[0].propertyName + ". "
          + err.error.errors[0].errorList[0];
        alert(errorMsg);
        this.alertService.tosterDanger(errorMsg);
      }
    });
  }

  // public hasBranch: boolean = false;
}
