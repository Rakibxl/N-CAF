import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../Services/Users/auth.service';

@Injectable({
  providedIn: 'root'
})
export class PermissionGuard implements CanActivate {
  
  constructor(
    private router: Router, 
    private authService: AuthService,
  ) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const isLoggedIn = this.authService.isLoggedIn && !this.authService.isTokenExpired;
      if (isLoggedIn) {
        if (next.data.permissions && !this.authService.hasPermission(next.data.permissions as Array<string>)) {
          this.router.navigate(['/auth/unauthorized']);
          return false;
        }
        
        return true;
      }
      
      this.router.navigate(['/auth/login'], { queryParams: { returnUrl: state.url } });
      return false; 
  }
}

