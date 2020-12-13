import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profMovementInfo extends Auditable {
    public MovementInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    //    public int ? CountryNameId { get; set; }
    //    public virtual CountryName CountryName { get; set; }
    public countryName: string;

    public countryNameId: number;

    public purpose: string;

    public status: string

    public startDate: Date;

    public endDate: Date;

}


