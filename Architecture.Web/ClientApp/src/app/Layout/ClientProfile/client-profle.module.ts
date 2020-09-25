import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientProfleRoutingModule } from './client-profle-routing.module';
import { BasicInformationComponent } from './basic-information/basic-information.component';
import { OccupationHistoryComponent } from './occupation-history/occupation-history.component';
import { FamilyInformationComponent } from './family-information/family-information.component';
import { EducationalInformationComponent } from './educational-information/educational-information.component';
import { AddressInformationComponent } from './address-information/address-information.component';
import { HouseRentInformationComponent } from './house-rent-information/house-rent-information.component';
import { DocumentInformationComponent } from './document-information/document-information.component';
import { IncomeInformationComponent } from './income-information/income-information.component';
import { MovementInformationComponent } from './movement-information/movement-information.component';
import { LegalInformationComponent } from './legal-information/legal-information.component';
import { InsuranceInformationComponent } from './insurance-information/insurance-information.component';
import { BankInformationComponent } from './bank-information/bank-information.component';
import { WorkerInformationComponent } from './worker-information/worker-information.component';
import { AssetInformationComponent } from './asset-information/asset-information.component';
import { DeligationInformationComponent } from './deligation-information/deligation-information.component';
import { IseeInformationComponent } from './isee-information/isee-information.component';


@NgModule({
    declarations: [BasicInformationComponent,OccupationHistoryComponent,FamilyInformationComponent, EducationalInformationComponent, AddressInformationComponent, HouseRentInformationComponent, DocumentInformationComponent, IncomeInformationComponent, MovementInformationComponent, LegalInformationComponent, InsuranceInformationComponent, BankInformationComponent, WorkerInformationComponent, AssetInformationComponent, DeligationInformationComponent, IseeInformationComponent],
  imports: [
    CommonModule,
    ClientProfleRoutingModule
  ]
})
export class ClientProfleModule { }
