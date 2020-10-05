import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-application-user-form',
  templateUrl: './application-user-form.component.html',
  styleUrls: ['./application-user-form.component.css']
})
export class ApplicationUserFormComponent implements OnInit {

    constructor(private router:Router) { }

    public backBtnClick() {
        this.router.navigate(["/manager/user-info"]);
    }

  ngOnInit() {
  }

}
