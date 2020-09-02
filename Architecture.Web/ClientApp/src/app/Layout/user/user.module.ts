import { UserComponent } from './user.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRoutingModule } from './user-routing.module';
import { UserFormComponent } from './user-form/user-form.component';
import { UserListComponent } from './user-list/user-list.component';
import { SharedMasterModule } from 'src/app/Shared/Modules/shared-master/shared-master.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgSelectModule } from '@ng-select/ng-select';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UserDetailsComponent } from './user-details/user-details.component';

@NgModule({
  declarations: [
    UserComponent, 
    UserFormComponent, 
    UserListComponent,
    UserDetailsComponent,
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    SharedMasterModule,
    AngularFontAwesomeModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule
  ],
  providers: [
  ]
})
export class UserModule { }
