import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profDelegationInfo extends Auditable {
    public  DelegationInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }
    
    public Name: string;

    public SurName: string;

    public DateOfBirth: Date;

    public TaxCode: string;

    public RefNo: string;

    public Purpose: string;

    public DocumentIssueDate: Date;

    public ExpiryDate: Date;

    public IssuedBy: string;

    public Status: string;
        
}


