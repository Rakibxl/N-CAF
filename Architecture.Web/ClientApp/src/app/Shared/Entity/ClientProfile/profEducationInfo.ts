import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profEducationInfo extends Auditable {
    public educationInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    public degreeTypeId: number;
    //    public virtual degreeType DegreeType { get; set; }

    public degreeType: string;

    public institutionName: string;

    public universityAddress: string

    public activitiesAndSocieties: string

    public result: string

    public startYear: Date;

    public endYear: Date;

}


