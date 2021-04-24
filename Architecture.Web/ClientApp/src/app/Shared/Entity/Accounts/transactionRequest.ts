import { Data } from '@angular/router';
import { Auditable } from '../Common/auditable';

export class TransactionRequest extends Auditable {
    public transactionRequestId: number;
    public purpose: string;
    public approvedBy: string;
    public approvedDate: Date;
    public requestBy: string;
    public transactionId: number;
    public paymentType: number;
    public ownerTypeName: string;
    public paymentReceivedBy: string;
    public paymentReceivedDate: Date;
        
}


