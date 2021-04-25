import {Component, OnInit} from '@angular/core';
import {ThemeOptions} from '../../../../../../theme-options';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { AuthService } from 'src/app/Shared/Services/Users/auth.service';
import { IAuthUser } from 'src/app/Shared/Entity/Users/auth';

@Component({
  selector: 'app-user-box',
  templateUrl: './user-box.component.html',
})
export class UserBoxComponent implements OnInit {
  user: IAuthUser;
  // production = false;

  constructor(
    public globals: ThemeOptions,
    private authService: AuthService,
    private router: Router) { 
    }

  ngOnInit() {
    // this.production = environment.production;
    this.authService.currentUser.subscribe(user => this.user = user);
    }

    fnRedirectToNotificationPage() {
        this.router.navigate(['/profile/notification']);
    }

    fnRedirectToChangePasswordPage() {
        this.router.navigate(['/profile/change-password']);
    }
    fnRedirectToProfileSettingsPage() {
        this.router.navigate(['/profile/settings']);
    }

    fnRedirectToAccountsPage() {
        //this.router.navigate(['/accounts/accounts-history']);
        this.router.navigate(['/accounts/recharge-money']);
    }

  logout() {
      this.authService.logout();
    this.router.navigate(['/auth/login']);
  }
}
