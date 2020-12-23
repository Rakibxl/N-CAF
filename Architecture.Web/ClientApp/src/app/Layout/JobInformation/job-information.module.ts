import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { JobInformationRoutingModule } from './job-information-routing.module';
import { JobListComponent } from './job-list/job-list.component';
import { JobFormComponent } from './job-form/job-form.component';
import { SharedMasterModule } from '../../Shared/Modules/shared-master/shared-master.module';
import { JobCollectionComponent } from './job-collection/job-collection.component';
import { NgSelectModule } from '@ng-select/ng-select';


@NgModule({
  declarations: [JobListComponent, JobFormComponent, JobCollectionComponent],
  imports: [
      CommonModule,
      FormsModule,
      JobInformationRoutingModule,
      NgSelectModule,
      SharedMasterModule
  ]
})
export class JobInformationModule { }
