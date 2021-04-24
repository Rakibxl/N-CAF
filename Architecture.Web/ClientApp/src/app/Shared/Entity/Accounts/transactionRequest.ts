import { Auditable } from '../Common/auditable';
import { PaymentType } from '../LU/paymentType';

export class TransactionRequest extends Auditable {
    public transactionRequestId: number;
    public purpose: string;
    public approvedBy: string;
    public approvedDate: Date;
    public requestBy: string;
    public transactionId: number;
    public paymentTypeId: number;
    public paymentType: PaymentType;
    public paymentReceivedBy: string;
    public paymentReceivedDate: Date;
    public amount: number;
}
