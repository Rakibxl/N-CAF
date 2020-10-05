import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
})
export class UserLoginComponent implements OnInit {
    @Output() OnClickChange = new EventEmitter() || null;
  constructor() { }

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
}
