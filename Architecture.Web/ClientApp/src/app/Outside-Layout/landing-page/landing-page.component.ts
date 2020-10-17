import { Component, OnInit, EventEmitter } from '@angular/core';
import { animationRightToggle } from '../../Shared/Modules/animations/animationRightToggle';

@Component({
    selector: 'app-landing-page',
    templateUrl: './landing-page.component.html',
    animations: [animationRightToggle]
})
export class LandingPageComponent implements OnInit {

    public openLogin: string = 'out';
    public regOpen: string = 'out';
    public openResetPass: string = "out";

    constructor() { }

    ngOnInit() {
    }

    public showLoginForm() {
        this.regOpen = 'out';
        this.openResetPass = "out";
        this.openLogin = this.openLogin === 'out' ? 'in' : 'out';
    }

    public showRegForm() {
        this.openLogin = 'out';
        this.openResetPass = "out";
        this.regOpen = this.regOpen === 'out' ? 'in' : 'out';
    }

    closePanel() {
        this.openResetPass = "out";
        this.openLogin = 'out';
        this.regOpen = 'out';
    }
    public showingPasswordResetForm() {
        this.openLogin = 'out';
        this.regOpen = "out";
        this.openResetPass = this.openResetPass === 'out' ? 'in' : 'out';
    }

    public fnOnClickLoginComponent(event: any) {
        console.log("event on click: ", event);
        if (event == "forgotPassword") {
            this.showingPasswordResetForm();
        } else if (event == "registration") {
            this.showRegForm();
        }

    }
    public fnOnClickRegComponent(event: any) {
        console.log("event on click: ", event);
        if (event == "loginForm") {
            this.showLoginForm();
        }

    }


}
