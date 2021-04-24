import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobFormComponent } from './job-form/job-form.component';
import { JobListComponent } from './job-list/job-list.component';


const routes: Routes = [
    {
        path: '',
        children: [
            { path: '', redirectTo: 'job-list' },
            { path: 'job-list', component: JobListComponent, data: { extraParameter: 'dashboard' } },
            { path: 'job-info-new/:id', component: JobFormComponent, data: { extraParameter: 'analytics' } },


        ]
    }    
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class JobInformationRoutingModule { }
