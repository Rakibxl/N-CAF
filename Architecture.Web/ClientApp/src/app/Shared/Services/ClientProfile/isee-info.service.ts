import { Injectable, Inject } from '@angular/core';
import { profISEEInfo } from '../../Entity/ClientProfile/profISEEInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ISEEInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public saveISEEInfo(data: profISEEInfo) {
        debugger;
        return this.http.post<APIResponse>(this.baseUrl + 'v1/ISEEInfo/CreateOrUpdate', data);
    }
    public getISEEInfo(profileId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/ISEEInfo/Profile/${profileId}`);
    }

    public getIseeById(profileId: number, iseeInfoId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/IseeInfo/GetById/${profileId}/${iseeInfoId}`);
    }
}
