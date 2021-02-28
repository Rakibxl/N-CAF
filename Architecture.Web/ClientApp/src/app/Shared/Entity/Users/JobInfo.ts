import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';
import { JobSectionLink } from './JobSectionLink';

export class JobInfo extends Auditable {
    public jobInfoId: number;
    public title: string;
    public description: string;
    public startDate: Date;
    public endDate: Date;
    public isCommon: boolean=false;
    public jobDeliveryTypeId: number;
    public jobDeliveryType: string;
    public operatorTimeFrame: number;
    public isHighlighted: boolean=false;
    public videoLink: string;
    public documentLink: string;
    public childAgeMin: number;
    public childAgeMax: number;
    public iseeMin: number;
    public iseeMax: number;
    public iseeClassTypeId: number;
    public iseeClassType: string;
    public isPregnant: boolean=false;
    public occupationTypeId: number;
    public occupationTypeName: string;
    public numberOfChild: number;
    public daysToExpairJobContract: number;
    public daysToBeExpairedResidencePermit: number;
    public isEligibleForUnlimitedResidencePermit: boolean=false;
    public daysToBeExpairedNationalId: number;
    public daysToBeExpairedPassport: number;
    public sectionNameId: number;
    public isEligibleForCityzenShipApply: boolean = false;
    public hasUnlimitedResidencePermit: boolean = false;
    public sectionName: string;
    public sectionList: string;
    public jobSectionLink: JobSectionLink[] = [];
}


