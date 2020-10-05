import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JobInformationRoutingModule } from './job-information-routing.module';
import { JobListComponent } from './job-list/job-list.component';
import { JobFormComponent } from './job-form/job-form.component';
import { SharedMasterModule } from '../../Shared/Modules/shared-master/shared-master.module';


@NgModule({
  declarations: [JobListComponent, JobFormComponent],
  imports: [
    CommonModule,
      JobInformationRoutingModule,
      SharedMasterModule
  ]
})
export class JobInformationModule { }