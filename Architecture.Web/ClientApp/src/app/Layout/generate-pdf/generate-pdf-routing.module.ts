import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CompleteOfferPdfComponent } from './complete-offer-pdf/complete-offer-pdf.component';
import { GeneratePdfComponent } from './generate-pdf/generate-pdf.component';


const routes: Routes = [
    { path: 'pdf/:profileId/:jobId/:offerId', component: GeneratePdfComponent },
    { path: 'completed-offer-pdf/:profileId/:jobId/:offerId', component: CompleteOfferPdfComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GeneratePdfRoutingModule { }
