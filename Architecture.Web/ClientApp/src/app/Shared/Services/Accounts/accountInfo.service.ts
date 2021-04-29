import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APIResponse } from '../../Entity/Response/api-response';
import { AccountInfo } from '../../Entity/Accounts/accountsInfo';

@Injectable({
  providedIn: 'root'
})
export class AccountInfoService {
    public baseUrl: string;
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.baseUrl = baseUrl + 'api/';
  }

    public saveAccountInfo(data: AccountInfo) {
        return this.http.post<APIResponse>(this.baseUrl + 'v1/AddressInfo/CreateOrUpdate', data);
    }
    public getAccountInfoById(accountInfoId: number) {
        return this.http.get<APIResponse>(this.baseUrl + `v1/AddressInfo/GetById/${accountInfoId}`);
    }
    public getAllAccountInfo() {
        return this.http.get<APIResponse>(this.baseUrl + `v1/AddressInfo/GetAllAccountInfo`);
    }
    public getCurrentUserAccountDetails() {
        return this.http.get<APIResponse>(this.baseUrl + `v1/AddressInfo/GetCurrentUserAccountDetails`);
    }
    public syncYourAccountInformation() {
        return this.http.get<APIResponse>(this.baseUrl + `v1/AddressInfo/SyncAccountInfo`);
    }
    public deleteById(accountInfoId: number) {
        return this.http.delete<APIResponse>(this.baseUrl + `v1/AddressInfo/DeleteById/${accountInfoId}`);
    }
}
