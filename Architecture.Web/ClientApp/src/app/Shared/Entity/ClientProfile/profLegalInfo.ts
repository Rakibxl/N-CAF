import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profLegalInfo extends Auditable {
    public LegalInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    //    public int ? CountryNameId { get; set; }
    //    public virtual CountryName CountryName { get; set; }

    public CityName: string;

    public IsAnyCase: boolean

    public RefNo: string;

    public Reason: string;

    public Note: string;

    public StartDate: Date;

    public EndDate: Date;
    
}


