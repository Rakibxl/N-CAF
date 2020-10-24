import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class profEducationInfo extends Auditable {
    public EducationInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }

    //    public int ? DegreeTypeId { get; set; }
    //    public virtual DegreeType DegreeType { get; set; }

    public InstitutionName: string;

    public UniversityAddress: string

    public ActivitiesAndSocieties: string

    public Result: string

    public StartYear: Date;

    public EndYear: Date;

}


