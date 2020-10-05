import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GeneratePdfRoutingModule } from './generate-pdf-routing.module';
import { GeneratePdfComponent } from './generate-pdf/generate-pdf.component';


@NgModule({
  declarations: [GeneratePdfComponent],
  imports: [
    CommonModule,
    GeneratePdfRoutingModule
  ]
})
export class GeneratePdfModule { }
