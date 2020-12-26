import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class JobInfo extends Auditable {
    public jobId: number;

    public title: string;

    public description: string;

    public startDate: Date;

    public endDate: Date;

    public isCommon: boolean;

    public jobDeliveryTypeId: number;

    public jobDeliveryType: string;

    public operatorTimeFrame: number;

    public isHighlighted: boolean;

    public videoLink: string;

    public documentLink: string;

    public childAgeMin: number;

    public childAgeMax: number;

    public iseeMin: number;

    public iseeMax: number;

    public iseeClassTypeId: number;

    public iseeClassType: string;

    public isPregnant: boolean;

    public occupationTypeId: number;

    public occupationTypeName: string;

    public numberOfChild: number;

    public daysToExpairJobContract: number;

    public daysToBeExpairedResidencePermit: number;

    public isEligibleForUnlimitedResidencePermit: boolean;

    public daysToBeExpairedNationalId: number;

    public daysToBeExpairedPassport: number;

    public sectionNameId: number;

    public isEligibleForCityzenShipApply: boolean;

    public hasUnlimitedResidencePermit: boolean;
    
}


