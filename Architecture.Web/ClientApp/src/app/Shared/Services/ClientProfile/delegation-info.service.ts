import { Injectable, Inject } from '@angular/core';
import { profDelegationInfo } from '../../Entity/ClientProfile/profDelegationInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DelegationInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public saveDelegationInfo(data: profDelegationInfo) {
        return this.http.post<APIResponse>(this.baseUrl + 'v1/DelegationInfo/CreateOrUpdate', data);
    }
    public getDelegationInfo(profileId: number) {
        return this.http.get<APIResponse>(this.baseUrl + `v1/DelegationInfo/Profile/${profileId}`);
    }

    public getDelegationById(profileId: number, delegationInfoId: number) {
        return this.http.get<APIResponse>(this.baseUrl + `v1/DelegationInfo/GetById/${profileId}/${delegationInfoId}`);
    }
}
