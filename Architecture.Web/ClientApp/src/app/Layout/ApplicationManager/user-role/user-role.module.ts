import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedMasterModule } from 'src/app/Shared/Modules/shared-master/shared-master.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgSelectModule } from '@ng-select/ng-select';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UserRoleListComponent } from './user-role-list/user-role-list.component';
import { UserRoleComponent } from './user-role.component';
import { UserRoleRoutingModule } from './user-role-routing.module';
import { UserRoleFormComponent } from './user-role-form/user-role-form.component';
import { RolePermissionsData } from './shared/user-role-permission-data';

@NgModule({
  declarations: [
    UserRoleComponent, 
    UserRoleFormComponent, 
    UserRoleListComponent,
  ],
  imports: [
    CommonModule,
    UserRoleRoutingModule,
    SharedMasterModule,
    AngularFontAwesomeModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule
  ],
  providers: [
    RolePermissionsData
  ],
  entryComponents: [
    UserRoleFormComponent
  ]

})
export class UserRoleModule { }
