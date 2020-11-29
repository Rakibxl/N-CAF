import { Injectable, Inject } from '@angular/core';
import { profBankInfo } from '../../Entity/ClientProfile/profBankInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BankInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public saveBankInfo(data: profBankInfo) {
        debugger;
        return this.http.post<APIResponse>(this.baseUrl + 'v1/BankInfo/CreateOrUpdate', data);
    }
    public getBankInfo(profileId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/BankInfo/Profile/${profileId}`);
    }

    public getBankById(profileId: number, bankInfoId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/BankInfo/GetById/${profileId}/${bankInfoId}`);
    }
}
