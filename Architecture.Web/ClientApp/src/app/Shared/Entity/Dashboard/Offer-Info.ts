import { Auditable } from '../Common/auditable';
import { JobInfo } from '../Users/JobInfo';

export class OfferInfo extends Auditable {
    public OfferInfoId: number;
    public JobId: number;
    public jobInfo: JobInfo;
    public jobTitle: string;
    public ProfileId: number;
    public profileName: string;
    public AcceptedOperatorId: string;
    public OperatorAcceptedDate: Date;
    public ValidatorId: string;
    public validatorName: string;
    public ValidationDate: Date;
    public OfferStatusId: number;
    public Status: string; 
    public CurrentUserId: string;
    public createdDate: string;
}