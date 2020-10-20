
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
      userId: [null],
      email: [null, Validators.required],
      phoneNumber: [null],
      password: [null, Validators.required],
      confirm_password: [null, Validators.required],
      genderId: [null]
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
    this.authService.register(formData).subscribe(res => {
      console.log(res)
    });
  }
}
