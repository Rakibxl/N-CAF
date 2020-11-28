import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profDelegationInfo extends Auditable {
    public  DelegationInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }
    
    public name: string;

    public surName: string;

    public dateOfBirth: Date;

    public taxCode: string;

    public refNo: string;

    public purpose: string;

    public documentIssueDate: Date;

    public expiryDate: Date;

    public issuedBy: string;

    public status: string;
        
}


