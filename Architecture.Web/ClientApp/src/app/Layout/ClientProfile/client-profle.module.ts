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
import { AssetInformationFormComponent } from './asset-information-form/asset-information-form.component';
import { BankInformationFormComponent } from './bank-information-form/bank-information-form.component';
import { DeligationInformationFormComponent } from './deligation-information-form/deligation-information-form.component';
import { DocumentInformationFormComponent } from './document-information-form/document-information-form.component';
import { EducationalInformationFormComponent } from './educational-information-form/educational-information-form.component';
import { FamilyInformationFormComponent } from './family-information-form/family-information-form.component';
import { HouseRentInformationFormComponent } from './house-rent-information-form/house-rent-information-form.component';
import { IncomeInformationFormComponent } from './income-information-form/income-information-form.component';
import { InsuranceInformationFormComponent } from './insurance-information-form/insurance-information-form.component';
import { IseeInformationFormComponent } from './isee-information-form/isee-information-form.component';
import { LegalInformationFormComponent } from './legal-information-form/legal-information-form.component';
import { MovementInformationFormComponent } from './movement-information-form/movement-information-form.component';
import { OccupationHistoryFormComponent } from './occupation-history-form/occupation-history-form.component';
import { WorkerInformationFormComponent } from './worker-information-form/worker-information-form.component';
import { AddressInformationFormComponent } from './address-information-form/address-information-form.component';
import { SharedMasterModule } from '../../Shared/Modules/shared-master/shared-master.module';


@NgModule({
    declarations: [BasicInformationComponent,OccupationHistoryComponent,FamilyInformationComponent, EducationalInformationComponent, AddressInformationComponent, HouseRentInformationComponent, DocumentInformationComponent, IncomeInformationComponent, MovementInformationComponent, LegalInformationComponent, InsuranceInformationComponent, BankInformationComponent, WorkerInformationComponent, AssetInformationComponent, DeligationInformationComponent, IseeInformationComponent, AssetInformationFormComponent, BankInformationFormComponent, DeligationInformationFormComponent, DocumentInformationFormComponent, EducationalInformationFormComponent, FamilyInformationFormComponent, HouseRentInformationFormComponent, IncomeInformationFormComponent, InsuranceInformationFormComponent, IseeInformationFormComponent, LegalInformationFormComponent, MovementInformationFormComponent, OccupationHistoryFormComponent, WorkerInformationFormComponent, AddressInformationFormComponent],
  imports: [
      CommonModule,
      SharedMasterModule,
    ClientProfleRoutingModule
  ]
})
export class ClientProfleModule { }
