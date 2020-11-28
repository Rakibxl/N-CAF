import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profOccupationInfo extends Auditable {
    public  OccupationInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

        //public int ? JobTypeId { get; set; }
        //public virtual JobType JobType { get; set; }


    //public int ? JobTypeId { get; set; }

    public jobTypeId: number;

    public jobHour: number;

    //public int ? ContractTypeId { get; set; }
     //public virtual ContractType ContractType { get; set; }

    public contractTypeId: number;

    public contractStartDate: Date;

    public contractEndDate: Date;

    public companyName: String;

    public vatNo: String;

    public legalCompanyAddress: String;

    public officeAddress: String;

    public branchAddress: String;

    public chamberOfCommerceRegNo: String;

    public chamberOfCommerceCityName: String;

    public REANo: String;

    public ATECONo: String;

    public SCIANo: String;

    public SCIACityName: String;

    public isShareHolder: number;

    public percentageOfShare: number;

    public notaioInfo: string;

    public companyRepresentative: string;
        
}


