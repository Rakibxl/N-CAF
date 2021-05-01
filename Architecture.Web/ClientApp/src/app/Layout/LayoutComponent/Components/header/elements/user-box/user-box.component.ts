import {Component, OnInit} from '@angular/core';
import {ThemeOptions} from '../../../../../../theme-options';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Shared/Services/Users/auth.service';
import { AccountInfoService } from 'src/app/Shared/Services/Accounts/accountInfo.service';
import { IAuthUser } from 'src/app/Shared/Entity/Users/auth';
import { AccountInfo } from '../../../../../../Shared/Entity/Accounts/accountsInfo';

@Component({
  selector: 'app-user-box',
  templateUrl: './user-box.component.html',
})
export class UserBoxComponent implements OnInit {
    user: IAuthUser;
    public accountInfo: AccountInfo = new AccountInfo();
  // production = false;

  constructor(
    public globals: ThemeOptions,
      private authService: AuthService,
      private accountInfoService: AccountInfoService,
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

    public getAccountBalance() {
        this.accountInfoService.getCurrentUserAccountDetails().subscribe(res => {
            this.accountInfo = res.data
        });
    }

  logout() {
      this.authService.logout();
    this.router.navigate(['/auth/login']);
  }
}
