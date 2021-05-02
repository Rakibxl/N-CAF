import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APIResponse } from '../../Entity/Response/api-response';
import { AccountInfo } from '../../Entity/Accounts/accountsInfo';
import { Transaction } from '../../Entity/Accounts/transaction';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
    public baseUrl: string;
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.baseUrl = baseUrl + 'api/';
  }

    public saveTransactionInfo(data: Transaction) {
        return this.http.post<APIResponse>(this.baseUrl + 'v1/Transaction/CreateOrUpdate', data);
    }
    public getTransactionById(transactionId: number) {
        return this.http.get<APIResponse>(this.baseUrl + `v1/Transaction/GetById/${transactionId}`);
    }
    public async getPendingTransactionInfo(): Promise<APIResponse> {
        return await this.http.get<APIResponse>(this.baseUrl + `v1/Transaction/GetPendingApprovalTransaction`).toPromise();
    }

    public async approvalRejectOperatorAmount(transactionId: number, status: string): Promise<APIResponse> {
       return await this.http.get<APIResponse>(this.baseUrl + `v1/Transaction/ApprovalRejectOperatorAmount/${transactionId}/${status}`).toPromise();
    }
    public deleteById(transactionId: number) {
        return this.http.delete<APIResponse>(this.baseUrl + `v1/Transaction/DeleteById/${transactionId}`);
    }
}
