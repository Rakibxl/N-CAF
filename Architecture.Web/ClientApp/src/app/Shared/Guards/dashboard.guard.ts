import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../Services/Users/auth.service';
import {IAuthUser} from '../Entity/Users/auth';

@Injectable({
    providedIn: 'root'
})
export class DashboardGuard implements CanActivate {
    user: IAuthUser;

    constructor(
        private authService: AuthService,
        private router: Router) {
    }

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        if (this.authService.isLoggedIn && !this.authService.isTokenExpired) {
            this.authService.currentUser.subscribe(user => this.user = user);
            const path = next.routeConfig.path;
            if (this.user.appUserTypeId === 2 || this.user.appUserTypeId === 1) {
                if(path === 'branch-user') return  true;
                this.router.navigate(['/dashboard/branch-user']);
            } else if (this.user.appUserTypeId === 3) {
                if(path === 'operator') return  true;
                this.router.navigate(['/dashboard/operator']);
            } else if (this.user.appUserTypeId === 4) {
                if (path === 'common') return true;
                this.router.navigate(['/dashboard/common']);
            } 
            return true;
        }
        else {
            this.router.navigate(['/auth/login'], { queryParams: { returnUrl: state.url } });
            return false;
        }
    }
}
