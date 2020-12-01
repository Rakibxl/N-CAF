import { Component, HostListener, OnInit } from '@angular/core';
import { ThemeOptions } from '../../../../theme-options';
import { select } from '@angular-redux/store';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
// import { MenuService } from 'src/app/Shared/Services/Menu-Details/menu.service';
// import { Menu } from 'src/app/Shared/Entity/Menu/menu.model';
import { environment } from 'src/environments/environment';
import { ClientProfileService } from '../../../../Shared/Services/ClientProfile/client-profile.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
})
export class SidebarComponent implements OnInit {
  public extraParameter: any;
  menuList: any[] = [];

  constructor(public globals: ThemeOptions, private router: Router, private activatedRoute: ActivatedRoute, private clientProfileService: ClientProfileService
    // private menuService: MenuService 
  ) {

  }

  @select('config') public config$: Observable<any>;

  private newInnerWidth: number;
  private innerWidth: number;
  private profileId: number;
  public educationInfoLink = "/client-profile/education";
  activeId = 'dashboardsMenu';
  prod: any;
  toggleSidebar() {
    this.globals.toggleSidebar = !this.globals.toggleSidebar;
  }

  sidebarHover() {
    this.globals.sidebarHover = !this.globals.sidebarHover;
  }

  ngOnInit() {
    this.prod = !environment.production;
    // debugger;
    this.profileId = +this.activatedRoute.snapshot.paramMap.get("profId") || 0;
    // this.profileId = this.clientProfileService.profileId;

    setTimeout(() => {

      this.innerWidth = window.innerWidth;
      if (this.innerWidth < 1200) {
        this.globals.toggleSidebar = true;
      }
    });

    this.extraParameter = this.activatedRoute.snapshot.firstChild.data.extraParameter || "";

    // this.getMenus();

  }

  onMenuClick(route) {
    if (this.clientProfileService.profileId) {
      this.router.navigate([`${route}${this.clientProfileService.profileId}`]);
    } else {
      this.router.navigate([`/client-profile/client-list`]);
    }
  }

  // getMenus() { 
  //   let roleId = 1;
  //   if(localStorage.getItem('userinfo')) {
  //       const userInfo = JSON.parse(localStorage.getItem('userinfo'));
  //       roleId = userInfo.roleId;
  //   }
  //   this.menuService.getPermissionMenus(roleId).subscribe(
  //     (res: any) => {
  //       console.log("Menus:................",res.data);
  //       this.menuList = res.data;        
  //     },
  //     (err: any) => {
  //       console.log(err);
  //     }
  //   );
  // }

  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.newInnerWidth = event.target.innerWidth;

    if (this.newInnerWidth < 1200) {
      this.globals.toggleSidebar = true;
    } else {
      this.globals.toggleSidebar = false;
    }

  }
}
