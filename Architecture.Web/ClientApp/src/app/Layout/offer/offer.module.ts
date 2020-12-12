import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OfferRoutingModule } from './offer-routing.module';
import { OfferComponent } from './offer/offer.component';
import { PTableModule } from '../../Shared/Modules/p-table/p-table.module';


@NgModule({
  declarations: [OfferComponent],
  imports: [
    CommonModule,
    OfferRoutingModule,
    PTableModule
  ]
})
export class OfferModule { }
