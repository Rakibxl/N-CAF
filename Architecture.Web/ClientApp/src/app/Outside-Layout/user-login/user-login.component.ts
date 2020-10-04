import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
})
export class UserLoginComponent implements OnInit {
    @Output() OnClickChange = new EventEmitter() || null;
  constructor() { }

  ngOnInit() {
  }

    public fnForgotPassword() {
        this.OnClickChange.emit("forgotPassword");

    }

    public fnRegistration() {
        this.OnClickChange.emit("registration");
    }
}
