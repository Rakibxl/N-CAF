import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profInsuranceInfo extends Auditable {
    public InsuranceInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

        //public int? InsuranceTypeId { get; set; }
        //public virtual InsuranceType InsuranceType { get; set; }

    public InsuranceTitle: string;

    public InsuranceAmount: number

    public InsuranceReturnPercentage: string;

    public StartDate: string;

    public EndDate: string;

}


