import { Auditable } from '../Common/auditable';

export class OfferInfo extends Auditable {
    public OfferInfoId: number;
    public JobId: number;
    public ProfileId: number;
    public AcceptedOperatorId: string;
    public OperatorAcceptedDate: Date;
    public ValidatorId: string;
    public ValidationDate: Date;
    public OfferStatusId: number;
    public Status: string; 
    public CurrentUserId: string;                
}