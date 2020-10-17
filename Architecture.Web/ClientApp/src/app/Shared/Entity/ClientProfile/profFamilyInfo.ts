import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class ProfFamilyInfo extends Auditable {
    public familyInfoId: number;
    public profileId: number;
    //public virtual ProfBasicInfo ProfBasicInfo { get; set; }
    public relationTypeId: number;
    //public virtual RelationType RelationType { get; set; }
    public name: string;
    public surName: string;
    public taxCode: string;
    public dateOfBirth: Data;
    public placeOfBirth: string;
    public phoneNumber: string;
    public occupationTypeId: number;
    //public virtual OccupationType OccupationType { get; set; }
    public nationlityId: number;
    //public virtual Nationality Nationality { get; set; }
    public previousNationality: string;
    public residenceScopeId: number;
    //public virtual ResidenceScope ResidenceScope { get; set; }
    public isDependent: boolean;
    public dependentPercentage: number;
    public isDisabled: boolean;
    public disabledPercentage: number;
    public yearlyIncome: number;
    public isAppliedForCitizenship: boolean;
    public applicationCode: string;
    public applicationDate: Date;
    public applicationCity: string;
    public applicationPlacedAddress: string;
    public applicationFileNumber: string;
    public applicationPlacedDate: Date;
}


