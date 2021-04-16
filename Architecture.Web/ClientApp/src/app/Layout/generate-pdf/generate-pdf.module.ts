import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GeneratePdfRoutingModule } from './generate-pdf-routing.module';
import { GeneratePdfComponent } from './generate-pdf/generate-pdf.component';
import { CompleteOfferPdfComponent } from './complete-offer-pdf/complete-offer-pdf.component';
import { DocumentCollectionComponent } from './complete-offer-pdf/document-collection/document-collection.component';
import { SharedMasterModule } from '../../Shared/Modules/shared-master/shared-master.module';


@NgModule({
  declarations: [GeneratePdfComponent, CompleteOfferPdfComponent, DocumentCollectionComponent],
  imports: [
    CommonModule,
      GeneratePdfRoutingModule,
      SharedMasterModule
  ]
})
export class GeneratePdfModule { }
