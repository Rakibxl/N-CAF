import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
})
export class UserLoginComponent implements OnInit {
    @Output() OnClickChange = new EventEmitter() || null;
    constructor(private router: Router) { }

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
        console.log("successfully login...");
        this.router.navigate(["/dashboard/common"]);
    }

    public hasBranch: boolean = false;
}
