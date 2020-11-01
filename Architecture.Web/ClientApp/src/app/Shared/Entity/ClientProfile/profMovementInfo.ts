import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profMovementInfo extends Auditable {
    public MovementInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    //    public int ? CountryNameId { get; set; }
    //    public virtual CountryName CountryName { get; set; }

    public Purpose: string;

    public Status: string

    public StartDate: Date;

    public EndDate: Date;

}


