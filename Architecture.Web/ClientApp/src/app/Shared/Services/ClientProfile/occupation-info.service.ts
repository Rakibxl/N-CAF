import { Injectable, Inject } from '@angular/core';
import { profOccupationInfo } from '../../Entity/ClientProfile/profOccupationInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class OccupationInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public saveOccupationInfo(data: profOccupationInfo) {
        return this.http.post<APIResponse>(this.baseUrl + 'v1/OccupationInfo/CreateOrUpdate', data);
    }
    public getOccupationInfo(profileId: number) {
        return this.http.get<APIResponse>(this.baseUrl + `v1/OccupationInfo/Profile/${profileId}`);
    }

    public getOccupationById(profileId: number, occupationInfoId: number) {
        return this.http.get<APIResponse>(this.baseUrl + `v1/OccupationInfo/GetById/${profileId}/${occupationInfoId}`);
    }
}
