import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddressInformationComponent } from './address-information/address-information.component';
import { BasicInformationComponent } from './basic-information/basic-information.component';
import { DocumentInformationComponent } from './document-information/document-information.component';
import { EducationalInformationComponent } from './educational-information/educational-information.component';
import { FamilyInformationComponent } from './family-information/family-information.component';
import { HouseRentInformationComponent } from './house-rent-information/house-rent-information.component';
import { IncomeInformationComponent } from './income-information/income-information.component';
import { MovementInformationComponent } from './movement-information/movement-information.component';
import { OccupationHistoryComponent } from './occupation-history/occupation-history.component';
import { LegalInformationComponent } from './legal-information/legal-information.component';
import { InsuranceInformationComponent } from './insurance-information/insurance-information.component';
import { BankInformationComponent } from './bank-information/bank-information.component';
import { WorkerInformationComponent } from './worker-information/worker-information.component';
import { AssetInformationComponent } from './asset-information/asset-information.component';
import { DeligationInformationComponent } from './deligation-information/deligation-information.component';
import { IseeInformationComponent } from './isee-information/isee-information.component';
import { OccupationHistoryFormComponent } from './occupation-history-form/occupation-history-form.component';
import { FamilyInformationFormComponent } from './family-information-form/family-information-form.component';
import { EducationalInformationFormComponent } from './educational-information-form/educational-information-form.component';
import { HouseRentInformationFormComponent } from './house-rent-information-form/house-rent-information-form.component';
import { DocumentInformationFormComponent } from './document-information-form/document-information-form.component';
import { IncomeInformationFormComponent } from './income-information-form/income-information-form.component';
import { MovementInformationFormComponent } from './movement-information-form/movement-information-form.component';
import { LegalInformationFormComponent } from './legal-information-form/legal-information-form.component';
import { InsuranceInformationFormComponent } from './insurance-information-form/insurance-information-form.component';
import { BankInformationFormComponent } from './bank-information-form/bank-information-form.component';
import { WorkerInformationFormComponent } from './worker-information-form/worker-information-form.component';
import { AssetInformationFormComponent } from './asset-information-form/asset-information-form.component';
import { DeligationInformationFormComponent } from './deligation-information-form/deligation-information-form.component';
import { IseeInformationFormComponent } from './isee-information-form/isee-information-form.component';
import { AddressInformationFormComponent } from './address-information-form/address-information-form.component';



const routes: Routes = [
    {
        path: '',
        children: [
            { path: '', redirectTo: 'basic-info' },
            { path: 'basic-info', component: BasicInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'occupation', component: OccupationHistoryComponent, data: { extraParameter: 'analytics' } },
            { path: 'occupation-new', component: OccupationHistoryFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'family-info', component: FamilyInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'family-info-new', component: FamilyInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'education', component: EducationalInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'education-new', component: EducationalInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'address', component: AddressInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'address-new', component: AddressInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'house-rent', component: HouseRentInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'house-rent-new', component: HouseRentInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'document-info-new', component: DocumentInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'income-info', component: IncomeInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'income-info-new', component: IncomeInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'movement-info', component: MovementInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'movement-info-new', component: MovementInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'legal-info', component: LegalInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'legal-info-new', component: LegalInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'insurance-info', component: InsuranceInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'insurance-info-new', component: InsuranceInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'bank-info', component: BankInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'bank-info-new', component: BankInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'worker-info', component: WorkerInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'worker-info-new', component: WorkerInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'asset-info', component: AssetInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'asset-info-new', component: AssetInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'deligation-info', component: DeligationInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'deligation-info-new', component: DeligationInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'isee-info', component: IseeInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'isee-info-new', component: IseeInformationFormComponent, data: { extraParameter: 'analytics' } }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ClientProfleRoutingModule { }


