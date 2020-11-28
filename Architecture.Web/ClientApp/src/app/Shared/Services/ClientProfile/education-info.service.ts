import { Injectable, Inject } from '@angular/core';
import { profEducationInfo } from '../../Entity/ClientProfile/profEducationInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EducationInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public saveEducationInfo(data: profEducationInfo) {
        debugger;
        return this.http.post<APIResponse>(this.baseUrl + 'v1/EducationInfo/CreateOrUpdate', data);
    }
    public getEducationInfo(profileId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/EducationInfo/Profile/${profileId}`);
    }
    public getEducaitonById(profileId: number, educationInfoId:number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/EducationInfo/GetById/${profileId}/${educationInfoId}`);
    }
}
