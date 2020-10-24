import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profOccupationInfo extends Auditable {
    public  OccupationInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

        //public int ? JobTypeId { get; set; }
        //public virtual JobType JobType { get; set; }

    public JobHour: number;

    //public int ? ContractTypeId { get; set; }
     //public virtual ContractType ContractType { get; set; }

    public ContractStartDate: Date;

    public ContractEndDate: Date;

    public CompanyName: String;

    public VATNo: String;

    public LegalCompanyAddress: String;

    public OfficeAddress: String;

    public BranchAddress: String;

    public ChamberOfCommerceRegNo: String;

    public ChamberOfCommerceCityName: String;

    public REANo: String;

    public ATECONo: String;

    public SCIANo: String;

    public SCIACityName: String;

    public IsShareHolder: number;

    public PercentageOfShare: number;

    public NotaioInfo: string;

    public CompanyRepresentative: string;
        
}


