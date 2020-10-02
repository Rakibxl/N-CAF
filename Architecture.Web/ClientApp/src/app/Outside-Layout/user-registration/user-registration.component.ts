import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
})
export class UserRegistrationComponent implements OnInit {
    @Output() OnClickChange = new EventEmitter() || null;
  constructor() { }

  ngOnInit() {
    }
    public showingLoginForm() {
        this.OnClickChange.emit("loginForm");
    }
}
