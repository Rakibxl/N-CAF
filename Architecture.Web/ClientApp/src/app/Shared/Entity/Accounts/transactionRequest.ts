import { Auditable } from '../Common/auditable';
import { PaymentType } from '../LU/paymentType';
import { QueryObject } from "../Common/query-object";

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
    public amount: number = 0.0;
}

export class TransactionRequestQuery extends QueryObject {
    name: string;

    constructor(init?: Partial<TransactionRequestQuery>) {
        super();
        Object.assign(this, init);
    }

    clear() {
        this.name = '';
    }
}
