import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user.component';
import { UserListComponent } from './user-list/user-list.component';
import { UserFormComponent } from './user-form/user-form.component';
import { UserDetailsComponent } from './user-details/user-details.component';


const routes: Routes = [{
  path: '',
  component: UserComponent,
  // canActivate: [AuthorizeGuard],
  children: [
    {
      path: '',
      redirectTo: 'users',
      pathMatch: 'full',
    },
    {
      path: 'users',
      component: UserListComponent,
      // canActivate: [AuthorizeGuard],
      // data: { title: 'Users', permissions: [RolePermissions.SuperAdmin, RolePermissions.Users.ListView] },
    },
    {
      path: 'new',
      component: UserFormComponent,
      // canActivate: [AuthorizeGuard],
      // data: { title: 'New User', permissions: [RolePermissions.SuperAdmin, RolePermissions.Users.Create] },
    },
    {
      path: 'edit/:id',
      component: UserFormComponent,
      // canActivate: [AuthorizeGuard],
      // data: { title: 'Edit User', permissions: [RolePermissions.SuperAdmin, RolePermissions.Users.Edit] },
    },
    {
      path: 'details/:id',
      component: UserDetailsComponent
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
export class UserRoutingModule { }
