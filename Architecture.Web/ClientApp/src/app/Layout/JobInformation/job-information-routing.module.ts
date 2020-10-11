import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobFormComponent } from './job-form/job-form.component';
import { JobCollectionComponent } from './job-collection/job-collection.component';
import { JobListComponent } from './job-list/job-list.component';


const routes: Routes = [
    {
        path: '',
        children: [
            { path: '', redirectTo: 'job-list' },
            { path: 'job-list', component: JobListComponent, data: { extraParameter: 'dashboard' } },
            { path: 'job-info-new', component: JobFormComponent, data: { extraParameter: 'analytics' } },


        ]
    }
    //{
    //    path: '',
    //    children: [
    //        { path: '', redirectTo: 'jobs' },
    //        { path: 'jobs', component: JobCollectionComponent, data: { extraParameter: 'analytics' } },
    //        { path: 'jobs/:id', component: JobFormComponent, data: { extraParameter: 'analytics' } }
    //    ]
    //}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class JobInformationRoutingModule { }
