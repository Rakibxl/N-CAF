import { Injectable, Inject } from '@angular/core';
import { profIncomeInfo } from '../../Entity/ClientProfile/profIncomeInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class IncomeInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public saveIncomeInfo(data: profIncomeInfo) {
        debugger;
        return this.http.post<APIResponse>(this.baseUrl + 'v1/IncomeInfo/CreateOrUpdate', data);
    }
    public getIncomeInfo(profileId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/IncomeInfo/Profile/${profileId}`);
    }

    public getIncomeById(profileId: number, incomeInfoId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/IncomeInfo/GetById/${profileId}/${incomeInfoId}`);
    }
}
