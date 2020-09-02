import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { UserRoleComponent } from './user-role.component';
import { UserRoleListComponent } from './user-role-list/user-role-list.component';


const routes: Routes = [{
  path: '',
  component: UserRoleComponent,
  // canActivate: [AuthorizeGuard],
  children: [
    {
      path: '',
      redirectTo: 'roles',
      pathMatch: 'full',
    },
    {
      path: 'roles',
      component: UserRoleListComponent,
      // canActivate: [AuthorizeGuard],
      // data: { title: 'Users', permissions: [RolePermissions.SuperAdmin, RolePermissions.Users.ListView] },
    },
  ],
}];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ],
  exports: [RouterModule],
})
export class UserRoleRoutingModule { }
