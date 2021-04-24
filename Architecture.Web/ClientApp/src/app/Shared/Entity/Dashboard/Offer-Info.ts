import { Auditable } from '../Common/auditable';
import { JobInfo } from '../Users/JobInfo';

export class OfferInfo extends Auditable {
    public offerInfoId: number;
    public jobId: number;
    public jobInfo: JobInfo;
    public jobTitle: string;
    public profileId: number;
    public profileName: string;
    public acceptedOperatorId: string;
    public operatorAcceptedDate: Date;
    public validatorId: string;
    public validatorName: string;
    public validationDate: Date;
    public offerStatusId: number;
    public status: string; 
    public currentUserId: string;
    public createdDate: string;
}