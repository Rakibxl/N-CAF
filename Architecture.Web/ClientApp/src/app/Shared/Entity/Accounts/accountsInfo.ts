import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';
import { AppUserType } from '../LU/appUserType';

export class AccountInfo extends Auditable {
    public accountInfoId: number;
    public accountNumber: string;
    public accountName: string;    
    public masterId: string
    public appUserTypeId: number;
    public appUserType: AppUserType;    
    public balanceAmount: number;
    public pendingAmount: number;        
}




