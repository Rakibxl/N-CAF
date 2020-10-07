
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
})
export class UserRegistrationComponent implements OnInit {
    @Output() OnClickChange = new EventEmitter() || null;
    constructor(private router: Router) { }

  otpEnable: boolean = false;
  myOptions: any = [];

    ngOnInit() { }
    public toggleOptEnable = () => this.otpEnable = !this.otpEnable;

    public showingLoginForm() {
        this.OnClickChange.emit("loginForm");
    }

    public fnLogin() {
        this.router.navigate(["/dashboard/common"]);
    }
}
