import { Auditable } from '../Common/auditable';

export class TransactionDetail extends Auditable {
    public transactionDetailId: number;
    public transactionId: number;    
    public debit: number;
    public credit: string;
        
}