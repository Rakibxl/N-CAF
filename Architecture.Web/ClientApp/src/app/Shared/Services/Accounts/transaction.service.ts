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
    public getPendingTransactionInfo(): Promise<APIResponse> {
        return this.http.get<APIResponse>(this.baseUrl + `v1/Transaction/GetPendingApprovalTransaction`).toPromise();
    }

    public approvalRejectOperatorAmount(transactionId: number, status: string): Promise<APIResponse> {
        return this.http.get<APIResponse>(this.baseUrl + `v1/Transaction/ApprovalRejectOperatorAmount?transactionId=${transactionId}&status=${status}`).toPromise();
    }
    public deleteById(transactionId: number) {
        return this.http.delete<APIResponse>(this.baseUrl + `v1/Transaction/DeleteById/${transactionId}`);
    }
}
