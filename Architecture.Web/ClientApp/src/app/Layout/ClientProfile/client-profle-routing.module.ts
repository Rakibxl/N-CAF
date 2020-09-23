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



const routes: Routes = [
    {
        path: '',
        children: [
            { path: '', redirectTo: 'basic-info' },
            { path: 'basic-info', component: BasicInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'occupation', component: OccupationHistoryComponent, data: { extraParameter: 'analytics' } },
            { path: 'family-info', component: FamilyInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'education', component: EducationalInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'address', component: AddressInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'house-rent', component: HouseRentInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'document-info', component: DocumentInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'income-info', component: IncomeInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'movement-info', component: MovementInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'movement-info', component: MovementInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'legal-info', component: LegalInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'insurance-info', component: InsuranceInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'bank-info', component: BankInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'worker-info', component: WorkerInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'asset-info', component: AssetInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'deligation-info', component: DeligationInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'isee-info', component: IseeInformationComponent, data: { extraParameter: 'analytics' } }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ClientProfleRoutingModule { }
