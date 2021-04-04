import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';
import { JobInfo } from './JobInfo';

export class OfferInfo extends Auditable {
    public OfferInfoId: number;
    public jobId: number;
    public jobInfo: JobInfo;
    public profileId: number;
    public profBasicInfo: any;
    public profileName: string;
    public acceptedOperatorId: string;
    public acceptedOperatorName: string;
    public operatorAcceptedDate: Date;
    public validatorId: string;
    public validatorName: string;
    public validationDate: Date;
    public offerStatusId: string;
    public offerStatus: any;
    public Status: string;
    public CurrentUserId: string;
}


