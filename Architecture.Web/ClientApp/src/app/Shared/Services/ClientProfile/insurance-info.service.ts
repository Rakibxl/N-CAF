import { Injectable, Inject } from '@angular/core';
import { profInsuranceInfo } from '../../Entity/ClientProfile/profInsuranceInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class InsuranceInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public saveInsuranceInfo(data: profInsuranceInfo) {
        return this.http.post<APIResponse>(this.baseUrl + 'v1/InsuranceInfo/CreateOrUpdate', data);
    }
    public getInsuranceInfo(profileId: number) {
        return this.http.get<APIResponse>(this.baseUrl + `v1/InsuranceInfo/Profile/${profileId}`);
    }

    public getInsuranceById(profileId: number, insuranceInfoId: number) {
        return this.http.get<APIResponse>(this.baseUrl + `v1/InsuranceInfo/GetById/${profileId}/${insuranceInfoId}`);
    }
}
