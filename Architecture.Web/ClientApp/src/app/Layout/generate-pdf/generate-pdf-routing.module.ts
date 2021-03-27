import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GeneratePdfComponent } from './generate-pdf/generate-pdf.component';


const routes: Routes = [
     { path: 'pdf/:profileId/:jobId/:offerId', component: GeneratePdfComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GeneratePdfRoutingModule { }
