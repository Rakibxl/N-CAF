import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profBankInfo extends Auditable {
    public BankInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

     //    public int ? BankNameId { get; set; }
    //    public virtual BankName BankName { get; set; }

    public BranchName: string;

    public AccountNumber: string;

    public SwiftNumber: string;
    
}


