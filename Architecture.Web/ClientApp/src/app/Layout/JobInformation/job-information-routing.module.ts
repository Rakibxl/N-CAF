import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobFormComponent } from './job-form/job-form.component';
import { JobCollectionComponent } from './job-collection/job-collection.component';


const routes: Routes = [
    {
        path: '',
        children: [
            { path: '', redirectTo: 'job-list' },
            { path: 'job-list', component: JobCollectionComponent, data: { extraParameter: 'dashboard' } },
            { path: 'job-list/:id', component: JobFormComponent, data: { extraParameter: 'dashboard' } },

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
