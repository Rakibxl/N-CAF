import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../Shared/Services/Users/auth.service';
import { AlertService } from '../../Shared/Modules/alert/alert.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
})
export class UserLoginComponent implements OnInit {
  @Output() OnClickChange = new EventEmitter() || null;
  loginModel: any = {
    email: '',
    password: '',
    branch: '',
  };

  constructor(private router: Router, private authService: AuthService, private alertService: AlertService) { }

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
    this.alertService.fnLoading(true);
    this.authService.login(this.loginModel).subscribe(res => {
      console.log("successfully login...");
      console.log(res)
      this.router.navigate(["/dashboard/common"]);
      this.alertService.fnLoading(false);
    }, error => {

    });
  }

  public hasBranch: boolean = false;
}
