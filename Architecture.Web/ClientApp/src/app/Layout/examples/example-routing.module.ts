import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ExampleComponent } from './example.component';
import { ExampleListComponent } from './example-list/example-list.component';
import { ExampleFormComponent } from './example-form/example-form.component';


const routes: Routes = [
  {
    path: '',
    component: ExampleComponent,
    children: [
      {
        path: '',
        redirectTo: 'list',
        pathMatch: 'full',
      },
      {
        path: 'list',
        component: ExampleListComponent
      },
      {
        path: 'new',
        component: ExampleFormComponent,
        // canActivate: [AuthorizeGuard],
        // data: { title: 'New User', permissions: [RolePermissions.SuperAdmin, RolePermissions.Users.Create] },
      },
      {
        path: 'edit/:id',
        component: ExampleFormComponent,
        // canActivate: [AuthorizeGuard],
        // data: { title: 'Edit User', permissions: [RolePermissions.SuperAdmin, RolePermissions.Users.Edit] },
      },
    ],

  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExampleRoutingModule { }
