import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profBankInfo extends Auditable {
    public BankInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

     //    public int ? BankNameId { get; set; }
    //    public virtual BankName BankName { get; set; }

    public bankNameId: number;

    public branchName: string;

    public accountNumber: string;

    public swiftNumber: string;

    public status: string;
    
}


