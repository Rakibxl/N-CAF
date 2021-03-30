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
import { ClientListComponent } from './client-list/client-list.component';



const routes: Routes = [
    {
        path: '',
        children: [
            { path: '', redirectTo: 'basic-info', pathMatch: 'full' },
            { path: 'client-list', component: ClientListComponent, data: { extraParameter: 'analytics' } },
            { path: 'basic-info/:profId', component: BasicInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'occupation/:profId', component: OccupationHistoryComponent, data: { extraParameter: 'analytics' } },
            { path: 'occupation/:profId/:id', component: OccupationHistoryFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'family-info/:profId', component: FamilyInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'family-info/:profId/:id', component: FamilyInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'education/:profId', component: EducationalInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'education/:profId/:id', component: EducationalInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'address/:profId', component: AddressInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'address/:profId/:id', component: AddressInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'house-rent/:profId', component: HouseRentInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'house-rent/:profId/:id', component: HouseRentInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'document-info/:profId/:id', component: DocumentInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'income-info/:profId', component: IncomeInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'income-info/:profId/:id', component: IncomeInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'movement-info/:profId', component: MovementInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'movement-info/:profId/:id', component: MovementInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'legal-info/:profId', component: LegalInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'legal-info/:profId/:id', component: LegalInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'insurance-info/:profId', component: InsuranceInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'insurance-info/:profId/:id', component: InsuranceInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'bank-info/:profId', component: BankInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'bank-info/:profId/:id', component: BankInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'worker-info/:profId', component: WorkerInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'worker-info/:profId/:id', component: WorkerInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'asset-info/:profId', component: AssetInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'asset-info/:profId/:id', component: AssetInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'deligation-info/:profId', component: DeligationInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'deligation-info/:profId/:id', component: DeligationInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'isee-info/:profId', component: IseeInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'isee-info/:profId/:id', component: IseeInformationFormComponent, data: { extraParameter: 'analytics' } },
            { path: 'document-info/:profId', component: DocumentInformationComponent, data: { extraParameter: 'analytics' } },
            { path: 'document-info/:profId/:id', component: DocumentInformationFormComponent, data: { extraParameter: 'analytics' } }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ClientProfleRoutingModule { }


