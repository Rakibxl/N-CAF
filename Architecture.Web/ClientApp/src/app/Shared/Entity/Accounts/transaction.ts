import { Auditable } from '../Common/auditable';

export class Transaction extends Auditable {
    public transactionId: number;
    public transactionPurpose: string;
    public approvedDate: Date;
    public approvedBy: string;
    public isAutoAccounting: boolean;
    public amount: number;
        
}