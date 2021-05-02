import { Auditable } from '../Common/auditable';
import { TransactionDetail } from './transactionDetails';

export class Transaction extends Auditable {
    public transactionId: number;
    public transactionPurpose: string;
    public approvedDate: Date;
    public approvedBy: string;
    public isAutoAccounting: boolean;
    public amount: number;
    public transactionDetail: TransactionDetail[];
        
}