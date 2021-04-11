import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GeneratePdfRoutingModule } from './generate-pdf-routing.module';
import { GeneratePdfComponent } from './generate-pdf/generate-pdf.component';
import { CompleteOfferPdfComponent } from './complete-offer-pdf/complete-offer-pdf.component';


@NgModule({
  declarations: [GeneratePdfComponent, CompleteOfferPdfComponent],
  imports: [
    CommonModule,
    GeneratePdfRoutingModule
  ]
})
export class GeneratePdfModule { }
