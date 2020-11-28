import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profInsuranceInfo extends Auditable {
    public InsuranceInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

        //public int? InsuranceTypeId { get; set; }
        //public virtual InsuranceType InsuranceType { get; set; }
    public insuranceTypeId: number;

    public insuranceTitle: string;

    public insuranceAmount: number

    public insuranceReturnPercentage: string;

    public startDate: string;

    public endDate: string;

}


