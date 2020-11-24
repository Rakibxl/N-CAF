import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profLegalInfo extends Auditable {
    public LegalInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    //    public int ? CountryNameId { get; set; }
    //    public virtual CountryName CountryName { get; set; }

    public countryNameId: number;

    public cityName: string;

    public isAnyCase: boolean

    public refNo: string;

    public reason: string;

    public note: string;

    public startDate: Date;

    public endDate: Date;
    
}


