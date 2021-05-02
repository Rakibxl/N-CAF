import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { HttpClient} from '@angular/common/http';

import { AccountsRoutingModule } from './accounts-routing.module';
import { AccountsHistoryComponent } from './accounts-history/accounts-history.component';
import { RechargeMoneyComponent } from './recharge-money/recharge-money.component';
import { RechargeApprovalComponent } from './recharge-approval/recharge-approval.component';
import { AccountInfoListComponent } from './account-info-list/account-info-list.component';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { SharedMasterModule } from "../../Shared/Modules/shared-master/shared-master.module";
import { OperatorAmountApprovalComponent } from './operator-amount-approval/operator-amount-approval.component';

export function httpLoaderFactory(http: HttpClient) {
    return new TranslateHttpLoader(http);
}


@NgModule({
    declarations: [AccountsHistoryComponent, RechargeMoneyComponent, RechargeApprovalComponent, AccountInfoListComponent, OperatorAmountApprovalComponent],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        NgSelectModule,
        AccountsRoutingModule,
        SharedMasterModule,
        TranslateModule.forRoot({
        loader: {
            provide: TranslateLoader,
            useFactory: httpLoaderFactory,
            deps: [HttpClient]
        },
        defaultLanguage: 'en'
    })
    ],
    exports: [AccountsHistoryComponent, RechargeMoneyComponent, RechargeApprovalComponent, AccountInfoListComponent, TranslateModule]
})

export class AccountsModule { }
