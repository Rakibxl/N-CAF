import { Injectable, Inject } from '@angular/core';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';
import { TransactionRequest } from "../../Entity/Accounts/transactionRequest";

@Injectable({
    providedIn: 'root'
})

export class RechargeService {
    public baseUrl: string;
    public endpoint: string;

    constructor(private http: HttpClient,
        @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
        this.endpoint = this.baseUrl + 'v1/Recharge';
    }

    public saveRechargeMoney(data: TransactionRequest) {
        return this.http.post<APIResponse>(this.endpoint + '/CreateOrUpdate', data);
    }

    getPendingRechargeApprovals() {
        return this.http.get<APIResponse>(this.endpoint + '/Pending');
    }

    approvePendingRechargeRequest(transactionRequestId: any) {
        return this.http.get<APIResponse>(this.endpoint + `/Approve/${transactionRequestId}`);
    }

    rejectPendingRechargeRequest(transactionRequestId: any) {
        return this.http.get<APIResponse>(this.endpoint + `/Reject/${transactionRequestId}`);
    }

}
