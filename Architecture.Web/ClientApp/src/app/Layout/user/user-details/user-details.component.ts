import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';
import { AlertService } from 'src/app/Shared/Modules/alert/alert.service';
import { UserService } from 'src/app/Shared/Services/Users/user.service';
import { finalize } from 'rxjs/operators';
import { User } from 'src/app/Shared/Entity/Users/user';
import { APIResponse } from 'src/app/Shared/Entity/Response/api-response';
import { EnumUserRoleDisplayName } from 'src/app/Shared/Enums/user-role';
import { MapObject } from 'src/app/Shared/Enums/map-object';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

  userGuid: string = "";
  user: User = new User();
  enumUserTypes: MapObject[] = EnumUserRoleDisplayName.EnumUserRoleTypeDisplayName;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private alertService: AlertService,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.userGuid = this.route.snapshot.params.id || "";
    this.getUser();
  }

  private getUser() {
    if (this.userGuid && Guid.isGuid(this.userGuid)) {
      this.alertService.fnLoading(true);
      this.userService.getUser(this.userGuid)
        .pipe(finalize(() => this.alertService.fnLoading(false)))
        .subscribe((res: APIResponse) => {
          if (res) {
            this.user = res.data as User;
            console.log(this.user);
            let role = this.enumUserTypes.filter(a => a.id == this.user.userRoleName)[0];
            this.user.userRoleDisplayName = (role) ? role.label : "";
          }
        });
    } else {

    }
  }

  public backToTheList() {
    this.router.navigate(['/users']);
  }

}
